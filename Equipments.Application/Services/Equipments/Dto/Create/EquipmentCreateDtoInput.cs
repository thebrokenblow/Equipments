namespace Equipments.Application.Services.Equipments.Dto.Create;

public class EquipmentCreateDtoInput
{
    public required string SerialNumber { get; set; }
    public required string CabinetNumber { get; set; }
    public required int TypeEquipmentId { get; init; }
    public required int EmployeeId { get; init; }
    public required int FacilityId { get; init; }
    public string? ConclusionSpecialProject { get; set; }
    public string? ConclusionSpecResearch { get; set; }
    public string? Note { get; set; }
}