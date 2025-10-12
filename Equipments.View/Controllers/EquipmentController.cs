using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.QueryModels.Employees;
using Equipments.Domain.QueryModels.Equipments;
using Equipments.View.Filters;
using Equipments.View.Helper;
using Equipments.View.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.Controllers;

/// <summary>
/// Контроллер для управления оборудованием
/// </summary>
public class EquipmentController(
    IEquipmentService equipmentService,
    IEmployeeService employeeService,
    ITypeEquipmentService typeEquipmentService,
    IFacilityService facilityService) : Controller
{
    private const int defaultNumberPage = 1;
    private const int defaultCountEquipmentsOnPage = 50;

    /// <summary>
    /// Отображает страницу списка оборудования с фильтрацией и пагинацией
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="pageNumber">Номер страницы</param>
    /// <param name="cabinetNumber">Номер кабинета для фильтрации</param>
    /// <param name="serialNumber">Серийный номер для фильтрации</param>
    /// <returns>Страница списка оборудования</returns>
    [HttpGet]
    public async Task<IActionResult> Index(
        int facilityId,
        int pageSize = defaultCountEquipmentsOnPage,
        int pageNumber = defaultNumberPage,
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
                                                 nameof(EmployeeModel.SurnameAndInitials));

        var typesEquipmentsSelectList = new SelectList(typesEquipmentsForSelect,
                                                       nameof(TypeEquipment.Id),
                                                       nameof(TypeEquipment.Name));

        var equipmentIndexViewModel = new EquipmentIndexViewModel
        {
            PagedEquipments = pagedEquipments,
            EquipmentFilterModel = equipmentFilterModel,
            EmployeesSelectList = employeesSelectList,
            TypesEquipmentsSelectList = typesEquipmentsSelectList
        };

        return View(equipmentIndexViewModel);
    }

    /// <summary>
    /// Создает новое оборудование
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <param name="equipment">Данные оборудования</param>
    /// <returns>Результат создания</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Create(int facilityId, Equipment equipment)
    {
        await equipmentService.AddAsync(equipment);
        return RedirectToMainPage(facilityId);
    }

    /// <summary>
    /// Отображает страницу подтверждения удаления оборудования
    /// </summary>
    /// <param name="equipmentId">Идентификатор оборудования</param>
    /// <returns>Страница подтверждения удаления</returns>
    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Delete(int equipmentId)
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

    /// <summary>
    /// Выполняет удаление оборудования
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <param name="equipmentId">Идентификатор оборудования</param>
    /// <returns>Результат удаления</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> DeleteConfirmed(int facilityId, int equipmentId)
    {
        try
        {
            await equipmentService.RemoveByIdAsync(equipmentId);

            return RedirectToMainPage(facilityId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Отображает страницу редактирования оборудования
    /// </summary>
    /// <param name="equipmentId">Идентификатор оборудования</param>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <returns>Страница редактирования</returns>
    [HttpGet]
    [AuthenticationRequired]
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
                                                     nameof(EmployeeModel.SurnameAndInitials));

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

    /// <summary>
    /// Выполняет обновление данных оборудования
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <param name="equipment">Обновленные данные оборудования</param>
    /// <returns>Результат обновления</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(int facilityId, Equipment equipment)
    {
        try
        {
            await equipmentService.UpdateAsync(equipment);
            return RedirectToMainPage(facilityId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Создает дубликат оборудования
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <param name="equipmentId">Идентификатор оборудования для дублирования</param>
    /// <returns>Результат дублирования</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Duplicate(int facilityId, int equipmentId)
    {
        try
        {
            await equipmentService.CreateDuplicateAsync(equipmentId);

            return RedirectToMainPage(facilityId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    // <summary>
    /// Перенаправляет на главную страницу управления оборудованием с учетом объекта
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта для фильтрации</param>
    /// <returns>Результат перенаправления на страницу списка оборудования</returns>
    public IActionResult RedirectToMainPage(int facilityId)
    {
        return RedirectToAction(
                        nameof(Index),
                        NameController.GetControllerName(nameof(EquipmentController)),
                        new { facilityId });
    }
}