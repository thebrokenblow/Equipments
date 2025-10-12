using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Filters;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

/// <summary>
/// Контроллер для управления объектами
/// </summary>
public class FacilityController(IFacilityService facilityService) : Controller
{
    /// <summary>
    /// Отображает страницу списка объектов
    /// </summary>
    /// <returns>Страница списка объектов</returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var facilities = await facilityService.GetAllAsync();

        return View(facilities);
    }

    /// <summary>
    /// Создает новый объект
    /// </summary>
    /// <param name="facility">Данные объекта</param>
    /// <returns>Результат создания</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Create(Facility facility)
    {
        await facilityService.AddAsync(facility);

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Отображает страницу редактирования объекта
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <returns>Страница редактирования</returns>
    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(int facilityId)
    {
        try
        {
            var facility = await facilityService.GetByIdAsync(facilityId);

            return View(facility);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Выполняет обновление данных объекта
    /// </summary>
    /// <param name="facility">Обновленные данные объекта</param>
    /// <returns>Результат обновления</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(Facility facility)
    {
        try
        {
            await facilityService.UpdateAsync(facility);

            return RedirectToMainPage();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Отображает страницу подтверждения удаления объекта
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <returns>Страница подтверждения удаления</returns>
    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Delete(int facilityId)
    {
        try
        {
            var facility = await facilityService.GetByIdAsync(facilityId);

            return View(facility);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Выполняет удаление объекта
    /// </summary>
    /// <param name="facilityId">Идентификатор объекта</param>
    /// <returns>Результат удаления</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> DeleteConfirmed(int facilityId)
    {
        try
        {
            await facilityService.RemoveByIdAsync(facilityId);

            return RedirectToMainPage();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Перенаправляет на главную страницу управления объектами
    /// </summary>
    /// <returns>Результат перенаправления на страницу списка объектов</returns>
    public IActionResult RedirectToMainPage()
    {
        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(FacilityController)));
    }
}