using Equipments.Application.Services.TypesEquipments;
using Equipments.Application.Services.TypesEquipments.Dto.Create;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class TypeEquipmentController(ITypeEquipmentService typeEquipmentService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(int facilityId, TypeEquipmentDtoInput typeEquipmentDtoInput)
    {
        await typeEquipmentService.AddAsync(typeEquipmentDtoInput);

        return RedirectToAction(
                    nameof(EquipmentController.Index),
                    NameController.GetControllerName(nameof(EquipmentController)),
                    new { facilityId });
    }
}
