namespace Equipments.View.Models;

/// <summary>
/// Сущность оборудования
/// </summary>
public class Equipment
{
    /// <summary>
    /// Уникальный идентификатор оборудования
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер оборудования (серийный номер)
    /// </summary>
    public required string SerialNumber { get; set; }

    /// <summary>
    /// Номер кабинета, где расположено оборудование
    /// </summary>
    public required string CabinetNumber { get; set; }

    /// <summary>
    /// Идентификатор типа оборудования (внешний ключ)
    /// </summary>
    public int TypeEquipmentId { get; set; }

    /// <summary>
    /// Навигационное свойство для типа оборудования
    /// </summary>
    public TypeEquipment? TypeEquipment { get; set; }

    /// <summary>
    /// Идентификатор сотрудника, за которым закреплено оборудование (внешний ключ)
    /// </summary>
    public required int EmployeeId { get; set; }

    /// <summary>
    /// Навигационное свойство для сотрудника
    /// </summary>
    public Employee? Employee { get; set; }

    /// <summary>
    /// Заключение о спец. проекте 
    /// </summary>
    public string? ConclusionSpecialProject { get; set; }

    /// <summary>
    /// Заключение о спец, исследовании 
    /// </summary>
    public string? ConclusionSpecResearch { get; set; }

    /// <summary>
    /// Дополнительные примечания к оборудованию
    /// </summary>
    public string? Note { get; set; }
}