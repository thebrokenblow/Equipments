using Equipments.View.Data;
using Equipments.View.Models;
using Equipments.View.ViewModels;
using Equipments.View.ViewModels.Employee;
using Equipments.View.ViewModels.Equipment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Equipments.View.Controllers;

public class EmployeeController(EquipmentsDbContext context) : Controller
{
    private const int pageSize = 10;

    public async Task<IActionResult> Index(int pageNumber = 1)
    {
        var querybleEmployees = context.Employees
                                       .AsQueryable();


        var count = await querybleEmployees.CountAsync();
        var employees = await querybleEmployees
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .Select(employee => new EmployeeViewModel
                                            {
                                                FirstName = employee.FirstName,
                                                LastName = employee.LastName,
                                                MiddleName = employee.MiddleName,
                                            })
                                            .AsNoTracking()
                                            .ToListAsync();

        var pageViewModel = new PageViewModel(count, pageNumber, pageSize);

        var employeeIndexViewModel = new EmployeeIndexViewModel
        {
            Employees = employees,
            PageViewModel = pageViewModel,
        };

        return View(employeeIndexViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EquipmentCreateViewModel equipmentCreateViewModel)
    {
        var equipment = new Equipment
        {
            SerialNumber = equipmentCreateViewModel.SerialNumber,
            CabinetNumber = equipmentCreateViewModel.CabinetNumber,
            TypeEquipmentId = equipmentCreateViewModel.TypeEquipmentId,
            EmployeeId = equipmentCreateViewModel.EmployeeId,
            ConclusionSpecialProject = equipmentCreateViewModel.ConclusionSpecialProject,
            ConclusionSpecResearch = equipmentCreateViewModel.ConclusionSpecResearch,
            Note = equipmentCreateViewModel.Note,
        };

        await context.Equipments.AddAsync(equipment);
        await context.SaveChangesAsync();

        return RedirectToAction("Index", "Equipment");
    }
}