using Equipments.Application.Exceptions;
using Equipments.Application.Services.Equipments;
using Equipments.Application.Services.Equipments.Dto.Create;
using Equipments.Application.Services.Equipments.Dto.Edit;
using Equipments.Application.Services.Equipments.Dto.Paged;
using Equipments.Domain;
using Equipments.View.Helper;
using Equipments.View.Vm;
using Equipments.View.Vm.EquipmentsVm.Create;
using Equipments.View.Vm.EquipmentsVm.Edit;
using Equipments.View.Vm.EquipmentsVm.Read;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.Controllers;

public class EquipmentController(IEquipmentService equipmentService) : Controller
{
    private const int pageSize = 10;

    [HttpGet]
    public async Task<IActionResult> Index(int facilityId, int pageNumber = 1, string? cabinetNumber = null, string? serialNumber = null)
    {
        var equipmentsPagedDtoInput = new EquipmentsPagedDtoInput
        {
            FacilityId = facilityId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            CabinetNumber = cabinetNumber,
            SerialNumber = serialNumber
        };

        var equipmentPagedVM = await equipmentService.GetPagedEquipmentsAsync(equipmentsPagedDtoInput);

        var employeesViewModel = equipmentPagedVM.EmployeesForCreateEquipment.Select(
                                                    employees => new EmployeesCreateEquipmentVm
                                                    {
                                                        Id = employees.Id,
                                                        FullName = $"{employees.LastName} {employees.FirstName} {employees.MiddleName}"
                                                    });

        var employeesSelectList = new SelectList(employeesViewModel,
                                                 nameof(EmployeesCreateEquipmentVm.Id),
                                                 nameof(EmployeesCreateEquipmentVm.FullName));

        var typesEquipmentsSelectList = new SelectList(equipmentPagedVM.TypesEquipmentForCreateEquipmen,
                                                       nameof(TypeEquipmentForCreateEquipmentDtoOutput.Id),
                                                       nameof(TypeEquipmentForCreateEquipmentDtoOutput.Name));

        var pageViewModel = new PageVm(equipmentPagedVM.CountEquipmentsWithFilter, pageNumber, pageSize);

        var filterViewModel = new EquipmentFilterVm
        {
            CabinetNumber = cabinetNumber,
            SerialNumber = serialNumber
        };

        var equipmentIndexViewModel = new EquipmentIndexVm
        {
            FacilityId = facilityId,
            Equipments = equipmentPagedVM.Equipments,
            PageViewModel = pageViewModel,
            FilterViewModel = filterViewModel,
            EmployeesSelectList = employeesSelectList,
            TypesEquipmentsSelectList = typesEquipmentsSelectList
        };

        return View(equipmentIndexViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EquipmentCreateDtoInput equipmentCreateDtoInput)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EquipmentController)),
                    new { facilityId = equipmentCreateDtoInput.FacilityId });
        }

        await equipmentService.AddAsync(equipmentCreateDtoInput);

        return RedirectToAction(
                nameof(Index), 
                NameController.GetControllerName(nameof(EquipmentController)), 
                new { facilityId = equipmentCreateDtoInput.FacilityId });
    }

    public async Task<IActionResult> Delete(int equipmentId, int facilityId)
    {
        try
        {
            await equipmentService.RemoveByIdAsync(equipmentId);
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

    [HttpGet]
    public async Task<IActionResult> Edit(int equipmentId, int facilityId)
    {
        var equipmentEditVm = await equipmentService.GetEquipmentForEditAsync(equipmentId);

        var employeesViewModel = equipmentEditVm.EmployeesForEditEquipment.Select(
            employees => new EmployeesEditEquipmentVm
            {
                Id = employees.Id,
                FullName = $"{employees.LastName} {employees.FirstName} {employees.MiddleName}"
            });

        var employeesSelectList = new SelectList(employeesViewModel,
                                                 nameof(EmployeesEditEquipmentVm.Id),
                                                 nameof(EmployeesEditEquipmentVm.FullName));

        var typesEquipmentsSelectList = new SelectList(equipmentEditVm.TypesEquipmentsForEditEquipmen,
                                                       nameof(TypeEquipment.Id),
                                                       nameof(TypeEquipment.Name));

        var facilitiesSelectList = new SelectList(equipmentEditVm.FacilitiesForEditEquipmen,
                                                       nameof(Facility.Id),
                                                       nameof(Facility.Name));


        var equipmentEditViewModel = new EquipmentVisualEditVm
        {
            FacilityId = facilityId,
            Equipment = equipmentEditVm.Equipment,
            FacilitiesSelectList = facilitiesSelectList,
            EmployeesSelectList = employeesSelectList,
            TypesEquipmentsSelectList = typesEquipmentsSelectList
        };

        return View(equipmentEditViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EquipmentEditDtoInput equipmentEditDtoInput)
    {
        try
        {
            await equipmentService.EditAsync(equipmentEditDtoInput);
        }
        catch(NotFoundException)
        {
            return NotFound();
        }

        return RedirectToAction(
                nameof(Index),
                NameController.GetControllerName(nameof(EquipmentController)),
                new { equipmentEditDtoInput.FacilityId });
    }
}