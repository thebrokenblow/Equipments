using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.ViewModels.Equipment;

public class EquipmentIndexViewModel
{
    public required List<EquipmentViewModel> Equipments { get; init; }
    public required PageViewModel PageViewModel { get; init; }
    public required EquipmentFilterViewModel FilterViewModel { get; init; }
    public required SelectList EmployeesSelectList { get; init; }
}