using Equipments.View.Data;
using Equipments.View.Models;
using Equipments.View.ViewModels;
using Equipments.View.ViewModels.Equipment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Equipments.View.Controllers;

public class EquipmentController(EquipmentsDbContext context) : Controller
{
    private const int pageSize = 10;

    public async Task<IActionResult> Index(int pageNumber = 1, string? cabinetNumber = null, string? serialNumber = null)
    {
        var querybleEquipments = context.Equipments
                                .Include(equipment => equipment.Employee)
                                .Include(equipment => equipment.TypeEquipment)
                                .AsQueryable();

        if (!string.IsNullOrEmpty(cabinetNumber))
        {
            querybleEquipments = querybleEquipments.Where(equipment => equipment.CabinetNumber.Contains(cabinetNumber.Trim()));
        }

        if (!string.IsNullOrEmpty(serialNumber))
        {
            querybleEquipments = querybleEquipments.Where(e => e.SerialNumber.Contains(serialNumber.Trim()));
        }

        var count = await querybleEquipments.CountAsync();
        var equipments = await querybleEquipments
                                            .Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .Select(equipment => new EquipmentViewModel
                                            {
                                                Id = equipment.Id,
                                                CabinetNumber = equipment.CabinetNumber,
                                                SerialNumber = equipment.SerialNumber,
                                                TypeEquipment = equipment.TypeEquipment.Name,
                                                FirstName = equipment.Employee == null ? string.Empty : equipment.Employee.FirstName,
                                                LastName = equipment.Employee == null ? string.Empty : equipment.Employee.LastName,
                                                MiddleName = equipment.Employee == null ? string.Empty : equipment.Employee.MiddleName,
                                                ConclusionSpecialProject = equipment.ConclusionSpecialProject,
                                                ConclusionSpecResearch = equipment.ConclusionSpecResearch,
                                                Note = equipment.Note,
                                            })
                                            .AsNoTracking()
                                            .ToListAsync();

        var employees = await context.Employees.ToListAsync();
        var employeesViewModel = employees.Select(x => new Test1 { Id = x.Id, Name = $"{x.FirstName} {x.LastName} {x.MiddleName}" });

        var employeesSelectList = new SelectList(employeesViewModel, nameof(Employee.Id), nameof(Test1.Name));

        var pageViewModel = new PageViewModel(count, pageNumber, pageSize);

        var filterViewModel = new EquipmentFilterViewModel
        {
            CabinetNumber = cabinetNumber,
            SerialNumber = serialNumber
        };

        var equipmentIndexViewModel = new EquipmentIndexViewModel
        {
            Equipments = equipments,
            PageViewModel = pageViewModel,
            FilterViewModel = filterViewModel,
            EmployeesSelectList = employeesSelectList
        };

        return View(equipmentIndexViewModel);
    }

    public class Test1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Test2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}