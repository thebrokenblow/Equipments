namespace Equipments.Domain.QueryModels.Equipments;

public class EquipmentDetailsListModel
{
    public required int Id { get; init; }
    public required string CabinetNumber { get; init; }
    public required string SerialNumber { get; init; }
    public required string TypeEquipment { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string? MiddleName { get; init; }
    public required string? ConclusionSpecialProject { get; init; }
    public required string? ConclusionSpecResearch { get; init; }
    public required string? Note { get; init; }
}