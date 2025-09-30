namespace Equipments.Domain.QueryModels.Equipments;

public class EquipmentListModel
{
    public int Id { get; init; }
    public string? CabinetNumber { get; init; }
    public string? SerialNumber { get; init; }
    public string? TypeEquipment { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? MiddleName { get; init; }
    public string? ConclusionSpecialProject { get; init; }
    public string? ConclusionSpecResearch { get; init; }
    public string? Note { get; init; }
}