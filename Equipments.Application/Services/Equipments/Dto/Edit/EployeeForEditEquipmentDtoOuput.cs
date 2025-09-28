namespace Equipments.Application.Services.Equipments.Dto.Edit;

public class EployeeForEditEquipmentDtoOuput
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string? MiddleName { get; init; }
}