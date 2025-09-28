using Equipments.Application.Services.Employees.Dto.Create;
using Equipments.Application.Services.Employees.Dto.Paged;

namespace Equipments.Application.Services.Employees;

public interface IEmployeeService
{
    Task<(List<EmployeePagedDtoOutput> Employees, int CountEmployee)> GetPagedEmployeesAsync(int pageNumber, int pageSize);
    Task AddAsync(EmployeeCreateDtoInput employeeCreateDtoInput);
    Task RemoveAsync(int id);
}