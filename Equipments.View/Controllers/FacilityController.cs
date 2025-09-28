using Equipments.Application.Services.Facilities;
using Equipments.Application.Services.Facilities.Dto.Create;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class FacilityController(IFacilitiesService facilitiesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var facilities = await facilitiesService.GelAllAsync();

        return View(facilities);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacilityCreateDtoInput facilityCreateDtoInput)
    {
        await facilitiesService.AddAsync(facilityCreateDtoInput);

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(FacilityController)));
    }
}