using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.QueryModels.Employees;
using Equipments.Domain.QueryModels.Equipments;
using Equipments.View.Helper;
using Equipments.View.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.Controllers;

public class EquipmentController(
    IEquipmentService equipmentService, 
    IEmployeeService employeeService, 
    ITypeEquipmentService typeEquipmentService,
    IFacilityService facilityService) : Controller
{
    private const int pageSize = 15;

    [HttpGet]
    public async Task<IActionResult> Index(
        int facilityId,
        int pageNumber = 1,
        string? cabinetNumber = null,
        string? serialNumber = null)
    {
        var equipmentFilterModel = new EquipmentFilterModel
        {
            FacilityId = facilityId,
            CabinetNumber = cabinetNumber,
            SerialNumber = serialNumber
        };

        var pagedEquipments = await equipmentService.GetFilteredPagedAsync(
                                                                pageNumber,
                                                                pageSize,
                                                                equipmentFilterModel);

        var employeesForSelect = await employeeService.GetForSelectAsync();
        var typesEquipmentsForSelect = await typeEquipmentService.GetAllAsync();


        var employeesSelectList = new SelectList(employeesForSelect,
                                                 nameof(EmployeeModel.Id),
                                                 nameof(EmployeeModel.FullName));

        var typesEquipmentsSelectList = new SelectList(typesEquipmentsForSelect,
                                                       nameof(TypeEquipment.Id),
                                                       nameof(TypeEquipment.Name));

        var equipmentIndexViewModel = new EquipmentIndexViewModel
        {
            PagedEquipments = pagedEquipments,
            EquipmentFilterModel = equipmentFilterModel,
            EmployeesSelectList = employeesSelectList,
            TypesEquipmentsSelectList = typesEquipmentsSelectList,
        };

        return View(equipmentIndexViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int facilityId, Equipment equipment)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EquipmentController)),
                    new { facilityId });
        }

        await equipmentService.AddAsync(equipment);

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(EquipmentController)),
                new { facilityId });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int equipmentId, int facilityId)
    {
        try
        {
            var equipment = await equipmentService.GetDetailsByIdAsync(equipmentId);
            return View(equipment);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int equipmentId)
    {
        try
        {
            await equipmentService.RemoveByIdAsync(equipmentId);

            return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int equipmentId, int facilityId)
    {
        try
        {
            var equipment = await equipmentService.GetByIdAsync(equipmentId);

            var employeesForSelect = await employeeService.GetForSelectAsync();
            var typesEquipmentsForSelect = await typeEquipmentService.GetAllAsync();
            var facilitiesForSelect = await facilityService.GetAllAsync();

            var employeesSelectList = new SelectList(employeesForSelect,
                                                     nameof(EmployeeModel.Id),
                                                     nameof(EmployeeModel.FullName));

            var typesEquipmentsSelectList = new SelectList(typesEquipmentsForSelect,
                                                           nameof(TypeEquipment.Id),
                                                           nameof(TypeEquipment.Name));

            var facilitiesSelectList = new SelectList(facilitiesForSelect,
                                                      nameof(Facility.Id),
                                                      nameof(Facility.Name));

            var equipmentEditViewModel = new EquipmentVisualEditViewModel
            {
                FacilityId = facilityId,
                Equipment = equipment,
                FacilitiesSelectList = facilitiesSelectList,
                EmployeesSelectList = employeesSelectList,
                TypesEquipmentsSelectList = typesEquipmentsSelectList
            };

            return View(equipmentEditViewModel);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int facilityId, Equipment equipment)
    {
        try
        {
            await equipmentService.UpdateAsync(equipment);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(EquipmentController)),
                new { facilityId });
    }

    public async Task<IActionResult> Duplicate(int facilityId, int equipmentId)
    {
        try
        {
            await equipmentService.DuplicateAsync(equipmentId);

            return RedirectToAction(
                        nameof(Index),
                        NameController.GetControllerName(nameof(EquipmentController)),
                        new { facilityId });
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}