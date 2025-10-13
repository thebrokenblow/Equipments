using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.View.Filters;
using Equipments.View.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class EmployeeController(IEmployeeService employeeService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(int pageSize = 50, int pageNumber = 1)
    {
        var pagedEmployees = await employeeService.GetPagedAsync(pageNumber, pageSize);

        return View(pagedEmployees);
    }

    [HttpPost]
    [AuthenticationRequired]
    public async Task<IActionResult> Create(Employee employee)
    {
        await employeeService.AddAsync(employee);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
    }

    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Delete(int employeeId)
    {
        var employee = await employeeService.GetByIdAsync(employeeId);
        return View(employee);
    }

    [HttpPost]
    [AuthenticationRequired]
    public async Task<IActionResult> DeleteConfirmed(int employeeId)
    {
        await employeeService.RemoveByIdAsync(employeeId);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
    }

    [HttpGet]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(int employeeId)
    {
        var employee = await employeeService.GetByIdAsync(employeeId);
        return View(employee);
    }

    [HttpPost]
    [AuthenticationRequired]
    public async Task<IActionResult> Edit(Employee employee)
    {
        await employeeService.UpdateAsync(employee);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
    }
}