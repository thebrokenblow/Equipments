namespace Equipments.Domain;

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
    /// Фамилия сотрудника
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Отчество сотрудника (необязательное поле)
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Навигационное свойство для оборудования, закрепленного за сотрудником
    /// </summary>
    public List<Equipment>? Equipments { get; set; }
}