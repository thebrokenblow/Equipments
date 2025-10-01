using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class FacilityController(IFacilityService facilityService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var facilities = await facilityService.GetAllAsync();

        return View(facilities);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Facility facility)
    {
        await facilityService.AddAsync(facility);

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(FacilityController)));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int facilityId)
    {
        var facility = await facilityService.GetByIdAsync(facilityId);

        return View(facility);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Facility facility)
    {
        await facilityService.UpdateAsync(facility);

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(FacilityController)));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int facilityId)
    {
        var facility = await facilityService.GetByIdAsync(facilityId);

        return View(facility);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int facilityId)
    {
        await facilityService.RemoveByIdAsync(facilityId);

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(FacilityController)));
    }
}