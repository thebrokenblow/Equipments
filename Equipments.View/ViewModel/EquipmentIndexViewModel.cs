using Equipments.Application.Common;
using Equipments.Domain.QueryModels.Equipments;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.ViewModel;

public class EquipmentIndexViewModel
{
    public required PagedResult<EquipmentDetailsListModel> PagedEquipments { get; init; }
    public required EquipmentFilterModel EquipmentFilterModel { get; init; }
    public required SelectList EmployeesSelectList { get; init; }
    public required SelectList TypesEquipmentsSelectList { get; init; }
}