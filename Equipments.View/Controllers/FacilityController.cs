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
}