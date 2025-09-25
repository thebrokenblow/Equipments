using Equipments.View.Data;
using Equipments.View.Repositories;
using Equipments.View.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EquipmentsDbContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Equipment}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();