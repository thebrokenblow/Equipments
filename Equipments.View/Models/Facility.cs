namespace Equipments.View.Models;

/// <summary>
/// Сущность объекта (предприятия)
/// </summary>
public class Facility
{
    /// <summary>
    /// Уникальный идентификатор объекта
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование объекта
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Навигационное свойство для оборудования, закрепленного за объектов (предприятием)
    /// </summary>
    public List<Equipment>? Equipment { get; set; }
}