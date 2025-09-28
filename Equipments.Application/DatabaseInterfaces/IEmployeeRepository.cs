using Equipments.Application.Services.Employees.Dto.Paged;
using Equipments.Domain;

namespace Equipments.Application.DatabaseInterfaces;

public interface IEmployeeRepository
{
    Task<(List<EmployeePagedDtoOutput> Employees, int CountEmployee)> GetRangeAsync(int countSkip, int countTake);
    Task<Employee?> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task RemoveAsync(Employee employee);
}