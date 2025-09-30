using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class EmployeeController(IEmployeeService employeeService) : Controller
{
    private const int pageSize = 20;

    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        var pagedEmployees = await employeeService.GetPagedAsync(pageNumber, pageSize);

        return View(pagedEmployees);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        await employeeService.AddAsync(employee);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
    }

    public async Task<IActionResult> Delete(int employeeId)
    {
        try
        {
            await employeeService.RemoveByIdAsync(employeeId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return RedirectToAction(
                   nameof(Index),
                   NameController.GetControllerName(nameof(EmployeeController)));
    }
}