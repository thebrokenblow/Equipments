using Equipments.Application.Services.Employees;
using Equipments.Application.Services.Equipments;
using Equipments.Application.Services.Facilities;
using Equipments.Application.Services.TypesEquipments;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IFacilitiesService, FacilitiesService>();
        services.AddScoped<ITypeEquipmentService, TypeEquipmentService>();

        return services;
    }
}