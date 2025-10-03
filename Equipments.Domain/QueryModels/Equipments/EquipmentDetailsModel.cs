namespace Equipments.Domain.QueryModels.Equipments;

public class EquipmentDetailsModel
{
    public required int Id { get; init; }
    public required string CabinetNumber { get; init; }
    public required string SerialNumber { get; init; }
    public required string TypeEquipment { get; init; }
    public required string SurnameAndInitials { get; init; }
    public required string? ConclusionSpecialProject { get; init; }
    public required string? ConclusionSpecResearch { get; init; }
    public required string? Note { get; init; }
    public required int FacilityId { get; init; }
    public required string FacilityName { get; init; }
}