using Equipments.Application.Exceptions;
using Equipments.Application.Services.Employees;
using Equipments.Application.Services.Employees.Dto.Create;
using Equipments.View.Helper;
using Equipments.View.Vm;
using Equipments.View.Vm.EmployeesVm.Read;
using Microsoft.AspNetCore.Mvc;

namespace Equipments.View.Controllers;

public class EmployeeController(IEmployeeService employeeService) : Controller
{
    private const int pageSize = 10;

    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        var (Employees, countEmployee) = await employeeService.GetPagedEmployeesAsync(pageNumber, pageSize);
        var pageViewModel = new PageVm(countEmployee, pageNumber, pageSize);

        var employeeIndexViewModel = new EmployeeIndexVm
        {
            Employees = Employees,
            PageViewModel = pageViewModel,
        };

        return View(employeeIndexViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateDtoInput employeeCreateDtoInput)
    {
        await employeeService.AddAsync(employeeCreateDtoInput);

        return RedirectToAction(
                    nameof(Index),
                    NameController.GetControllerName(nameof(EmployeeController)));
    }

    public async Task<IActionResult> Delete(int employeeId)
    {
        try
        {
            await employeeService.RemoveAsync(employeeId);
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