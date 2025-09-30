using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class TypeEquipmentController(ITypeEquipmentService typeEquipmentService) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(int facilityId, TypeEquipment typeEquipment)
    {
        await typeEquipmentService.AddAsync(typeEquipment);

        return RedirectToAction(
                    nameof(EquipmentController.Index),
                    NameController.GetControllerName(nameof(EquipmentController)),
                    new { facilityId });
    }
}