namespace Equipments.Domain.Entities;

/// <summary>
/// Сущность тип оборудования
/// </summary>
public class TypeEquipment
{
    /// <summary>
    /// Уникальный идентификатор типа оборудования
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование типа оборудования
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Навигационное свойство для оборудования данного типа
    /// </summary>
    public List<Equipment>? Equipments { get; set; }
}