namespace Equipments.View.ViewModels.Equipment;

public class EquipmentCreateViewModel
{
    public required string SerialNumber { get; set; }
    public required string CabinetNumber { get; set; }
    public int TypeEquipmentId { get; set; }
    public required int EmployeeId { get; set; }
    public string? ConclusionSpecialProject { get; set; }
    public string? ConclusionSpecResearch { get; set; }
    public string? Note { get; set; }
}