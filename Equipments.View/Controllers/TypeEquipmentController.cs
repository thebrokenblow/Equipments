using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Filters;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

/// <summary>
/// Контроллер для управления типами оборудования
/// </summary>
public class TypeEquipmentController(ITypeEquipmentService typeEquipmentService) : Controller
{
    /// <summary>
    /// Отображает страницу списка типов оборудования
    /// </summary>
    /// <returns>Страница списка типов оборудования</returns>
    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Index()
    {
        var typesEquipments = await typeEquipmentService.GetAllAsync();

        return View(typesEquipments);
    }

    /// <summary>
    /// Создает новый тип оборудования
    /// </summary>
    /// <param name="typeEquipment">Данные типа оборудования</param>
    /// <returns>Результат создания</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Create(TypeEquipment typeEquipment)
    {
        await typeEquipmentService.AddAsync(typeEquipment);

        return RedirectToMainPage();
    }

    /// <summary>
    /// Отображает страницу редактирования типа оборудования
    /// </summary>
    /// <param name="typeEquipmentId">Идентификатор типа оборудования</param>
    /// <returns>Страница редактирования</returns>
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

    /// <summary>
    /// Выполняет обновление данных типа оборудования
    /// </summary>
    /// <param name="typeEquipment">Обновленные данные типа оборудования</param>
    /// <returns>Результат обновления</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(TypeEquipment typeEquipment)
    {
        try
        {
            await typeEquipmentService.UpdateAsync(typeEquipment);

            return RedirectToMainPage();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Перенаправляет на главную страницу управления типами оборудования
    /// </summary>
    /// <returns>Результат перенаправления на страницу списка типов оборудования</returns>
    public IActionResult RedirectToMainPage()
    {
        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(TypeEquipmentController)));
    }
}