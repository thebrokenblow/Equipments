namespace Equipments.Domain.Entities;

/// <summary>
/// Сущность сотрудника
/// </summary>
public class Employee
{
    /// <summary>
    /// Уникальный идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Фамилия и инициалы сотрудника
    /// </summary>
    public required string SurnameAndInitials { get; set; }

    /// <summary>
    /// Наименование подразделения 
    /// </summary>
    public string? SubdivisionName { get; set; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Навигационное свойство для оборудования, закрепленного за сотрудником
    /// </summary>
    public List<Equipment>? Equipments { get; set; }
}