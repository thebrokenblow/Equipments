namespace Equipments.Application.Services.Equipments.Dto.Paged;

public class EquipmentsFilterDtoInput
{
    public required int FacilityId { get; init; }
    public required string? CabinetNumber { get; set; }
    public required string? SerialNumber { get; set; }
}