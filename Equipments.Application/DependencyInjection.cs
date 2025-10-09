using Equipments.Application.Services;
using Equipments.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.Application;

/// <summary>
/// Предоставляет методы расширения для регистрации сервисов приложения в контейнере зависимостей.
/// </summary>
/// <remarks>
/// Этот статический класс содержит конфигурацию IoC-контейнера для слоя приложения.
/// Все сервисы регистрируются с временем жизни Scoped, что обеспечивает создание одного экземпляра на область (request).
/// </remarks>
public static class DependencyInjection
{
    /// <summary>
    /// Регистрирует все сервисы приложения в контейнере зависимостей.
    /// </summary>
    /// <param name="services">Коллекция сервисов для регистрации</param>
    /// <returns>Коллекция сервисов с зарегистрированными зависимостями приложения</returns>
    /// <example>
    /// <code>
    /// // В Program.cs или Startup.cs
    /// services.AddApplication();
    /// </code>
    /// </example>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Регистрация сервисов с временем жизни Scoped
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEquipmentService, EquipmentService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<ITypeEquipmentService, TypeEquipmentService>();

        return services;
    }
}