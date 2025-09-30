using Equipments.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.ViewModel;

public class EquipmentVisualEditViewModel
{
    public required int FacilityId { get; init; }
    public required Equipment Equipment { get; init; }
    public required SelectList FacilitiesSelectList { get; init; }
    public required SelectList EmployeesSelectList { get; init; }
    public required SelectList TypesEquipmentsSelectList { get; init; }
}