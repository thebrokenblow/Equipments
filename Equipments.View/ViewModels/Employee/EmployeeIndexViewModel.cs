using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipments.View.ViewModels.Employee;

public class EmployeeIndexViewModel
{
    public required List<EmployeeViewModel> Employees { get; init; }
    public required PageViewModel PageViewModel { get; init; }
}