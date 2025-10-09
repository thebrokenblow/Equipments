namespace Equipments.Domain.QueryModels.Equipments;

/// <summary>
/// Модель фильтра для поиска оборудования
/// </summary>
public class EquipmentFilterModel
{
    /// <summary>
    /// Идентификатор учреждения/объекта для фильтрации
    /// </summary>
    public required int FacilityId { get; init; }

    /// <summary>
    /// Номер кабинета для фильтрации
    /// </summary>
    public required string? CabinetNumber { get; set; }

    /// <summary>
    /// Серийный номер для фильтрации
    /// </summary>
    public required string? SerialNumber { get; set; }
}