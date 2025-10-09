namespace Equipments.Domain.QueryModels.Equipments;

/// <summary>
/// Модель для отображения детальной информации об оборудовании
/// </summary>
public class EquipmentDetailsModel
{
    /// <summary>
    /// Уникальный идентификатор оборудования
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Номер кабинета, где расположено оборудование
    /// </summary>
    public required string CabinetNumber { get; init; }

    /// <summary>
    /// Номер оборудования (серийный номер)
    /// </summary>
    public required string SerialNumber { get; init; }

    /// <summary>
    /// Тип оборудования
    /// </summary>
    public required string TypeEquipment { get; init; }

    /// <summary>
    /// Фамилия и инициалы сотрудника, за которым закреплено оборудование
    /// </summary>
    public required string SurnameAndInitials { get; init; }

    /// <summary>
    /// Заключение о спец. проекте 
    /// </summary>
    public required string? ConclusionSpecialProject { get; init; }

    /// <summary>
    /// Заключение о спец. исследовании 
    /// </summary>
    public required string? ConclusionSpecResearch { get; init; }

    /// <summary>
    /// Дополнительные примечания к оборудованию
    /// </summary>
    public required string? Note { get; init; }

    /// <summary>
    /// Идентификатор учреждения/объекта, где расположено оборудование
    /// </summary>
    public required int FacilityId { get; init; }

    /// <summary>
    /// Наименование учреждения/объекта
    /// </summary>
    public required string FacilityName { get; init; }
}