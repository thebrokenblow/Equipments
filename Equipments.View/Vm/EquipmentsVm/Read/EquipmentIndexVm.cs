using Equipments.Application.Services.Equipments.Dto.Paged;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.Vm.EquipmentsVm.Read;

public class EquipmentIndexVm
{
    public required int FacilityId { get; init; }
    public required List<EquipmentsPagedDtoOutput> Equipments { get; init; }
    public required PageVm PageViewModel { get; init; }
    public required EquipmentFilterVm FilterViewModel { get; init; }
    public required SelectList EmployeesSelectList { get; init; }
    public required SelectList TypesEquipmentsSelectList { get; init; }
}