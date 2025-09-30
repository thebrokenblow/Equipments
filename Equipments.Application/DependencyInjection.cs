using Equipments.Application.Services;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Interfaces.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<ITypeEquipmentService, TypeEquipmentService>();

        return services;
    }
}