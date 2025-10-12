using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Filters;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

/// <summary>
/// Контроллер для управления данными сотрудников
/// </summary>
public class EmployeeController(IEmployeeService employeeService) : Controller
{
    private const int defaultNumberPage = 1;
    private const int defaultCountEmployeesOnPage = 50;

    /// <summary>
    /// Отображает страницу списка сотрудников с пагинацией
    /// </summary>
    /// <param name="pageSize">Размер страницы</param>
    /// <param name="pageNumber">Номер страницы</param>
    /// <returns>Страница списка сотрудников</returns>
    [HttpGet]
    public async Task<IActionResult> Index(int pageSize = defaultCountEmployeesOnPage, int pageNumber = defaultNumberPage)
    {
        var pagedEmployees = await employeeService.GetPagedAsync(pageNumber, pageSize);

        return View(pagedEmployees);
    }

    /// <summary>
    /// Создает нового сотрудника
    /// </summary>
    /// <param name="employee">Данные сотрудника</param>
    /// <returns>Результат создания</returns>
    [HttpPost]
    [AuthenticationRequired]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee)
    {
        await employeeService.AddAsync(employee);

        return RedirectToMainPage();
    }

    /// <summary>
    /// Отображает страницу подтверждения удаления сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <returns>Страница подтверждения удаления</returns>
    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Delete(int employeeId)
    {
        try
        {
            var employee = await employeeService.GetByIdAsync(employeeId);

            return View(employee);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Выполняет удаление сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <returns>Результат удаления</returns>
    [HttpPost]
    [AuthenticationRequired]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int employeeId)
    {
        try
        {
            await employeeService.RemoveByIdAsync(employeeId);

            return RedirectToMainPage();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Отображает страницу редактирования сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <returns>Страница редактирования</returns>
    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(int employeeId)
    {
        try
        {
            var employee = await employeeService.GetByIdAsync(employeeId);

            return View(employee);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Выполняет обновление данных сотрудника
    /// </summary>
    /// <param name="employee">Обновленные данные сотрудника</param>
    /// <returns>Результат обновления</returns>
    [HttpPost]
    [AuthenticationRequired]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Employee employee)
    {
        try
        {
            await employeeService.UpdateAsync(employee);

            return RedirectToMainPage();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Перенаправляет на главную страницу управления сотрудниками
    /// </summary>
    /// <returns>Результат перенаправления на страницу списка сотрудников</returns>
    public IActionResult RedirectToMainPage()
    {
        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
    }
}