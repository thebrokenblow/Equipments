using Equipments.Application.Services.Employees.Dto.Paged;

namespace Equipments.View.Vm.EmployeesVm.Read;

public class EmployeeIndexVm
{
    public required List<EmployeePagedDtoOutput> Employees { get; init; }
    public required PageVm PageViewModel { get; init; }
}