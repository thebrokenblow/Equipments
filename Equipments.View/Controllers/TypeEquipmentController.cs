using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Filters;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class TypeEquipmentController(ITypeEquipmentService typeEquipmentService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var typesEquipments = await typeEquipmentService.GetAllAsync();

        return View(typesEquipments);
    }

    [HttpPost]
    [AuthenticationRequired]
    public async Task<IActionResult> Create(TypeEquipment typeEquipment)
    {
        await typeEquipmentService.AddAsync(typeEquipment);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(TypeEquipmentController)));
    }

    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(int typeEquipmentId)
    {
        try
        {
            var typeEquipment = await typeEquipmentService.GetByIdAsync(typeEquipmentId);

            return View(typeEquipment);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(TypeEquipment typeEquipment)
    {
        await typeEquipmentService.UpdateAsync(typeEquipment);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(TypeEquipmentController)));
    }
}