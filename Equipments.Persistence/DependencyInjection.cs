using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Equipments.Persistence.Queries;
using Equipments.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.Persistence;

public static class DependencyInjection
{
    private const string titleConnectionString = "DbConnection";

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(titleConnectionString) ?? 
            throw new InvalidOperationException("Connection string is not initialized");

        services.AddDbContext<EquipmentsDbContext>(options => 
                                                        options.UseNpgsql(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<ITypeEquipmentRepository, TypeEquipmentRepository>();

        services.AddScoped<IEmployeeQueries, EmployeeQuery>();
        services.AddScoped<IEquipmentQueries, EquipmentQuery>();

        return services;
    }
}