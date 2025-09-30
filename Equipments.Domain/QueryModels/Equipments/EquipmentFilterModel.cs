namespace Equipments.Domain.QueryModels.Equipments;

public class EquipmentFilterModel
{
    public required int FacilityId { get; init; }
    public required string? CabinetNumber { get; set; }
    public required string? SerialNumber { get; set; }
}