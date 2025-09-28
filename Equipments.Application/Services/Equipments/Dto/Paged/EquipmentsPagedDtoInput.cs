namespace Equipments.Application.Services.Equipments.Dto.Paged;

public class EquipmentsPagedDtoInput
{
    public required int FacilityId { get; init; }
    public required int PageNumber { get; init; }
    public required int PageSize { get; init; }
    public required string? CabinetNumber { get; set; }
    public required string? SerialNumber { get; set; }
}