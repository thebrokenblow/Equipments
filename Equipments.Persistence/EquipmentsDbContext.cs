using Equipments.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence;

/// <summary>
/// Контекст базы данных для управления сущностями оборудования и сотрудников
/// </summary>
/// <remarks>
/// Предоставляет доступ к таблицам базы данных, связанным с учетом оборудования,
/// сотрудников, типов оборудования и объектов предприятия
/// </remarks>
public class EquipmentsDbContext(DbContextOptions<EquipmentsDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Набор данных сотрудников организации
    /// </summary>
    public DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// Набор данных оборудования предприятия
    /// </summary>
    public DbSet<Equipment> Equipments { get; set; }

    /// <summary>
    /// Набор данных типов оборудования
    /// </summary>
    public DbSet<TypeEquipment> TypeEquipments { get; set; }

    /// <summary>
    /// Набор данных объектов предприятия
    /// </summary>
    public DbSet<Facility> Facilities { get; set; }
}