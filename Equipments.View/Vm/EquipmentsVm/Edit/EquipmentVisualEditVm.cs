using Equipments.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.Vm.EquipmentsVm.Edit;

public class EquipmentVisualEditVm
{
    public required int FacilityId { get; init; }
    public required Equipment Equipment { get; init; }
    public required SelectList EmployeesSelectList { get; init; }
    public required SelectList TypesEquipmentsSelectList { get; init; }
    public required SelectList FacilitiesSelectList { get; init; }
}
