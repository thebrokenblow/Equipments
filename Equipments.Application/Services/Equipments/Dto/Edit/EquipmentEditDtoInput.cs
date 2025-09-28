namespace Equipments.Application.Services.Equipments.Dto.Edit;

public class EquipmentEditDtoInput
{
    public required int EquipmentId { get; init; }
    public required string SerialNumber { get; init; }
    public required string CabinetNumber { get; init; }
    public required int TypeEquipmentId { get; init; }
    public required int EmployeeId { get; init; }
    public required int FacilityId { get; init; }
    public string? ConclusionSpecialProject { get; init; }
    public string? ConclusionSpecResearch { get; init; }
    public string? Note { get; init; }
}