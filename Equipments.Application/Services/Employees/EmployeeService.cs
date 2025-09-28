using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Exceptions;
using Equipments.Application.Services.Employees.Dto.Create;
using Equipments.Application.Services.Employees.Dto.Paged;
using Equipments.Domain;

namespace Equipments.Application.Services.Employees;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task<(List<EmployeePagedDtoOutput> Employees, int CountEmployee)> GetPagedEmployeesAsync(int pageNumber, int pageSize)
    {
        int countSkip = (pageNumber - 1) * pageSize;
        var employeeRange = await employeeRepository.GetRangeAsync(countSkip, pageSize);

        return employeeRange;
    }

    public async Task RemoveAsync(int id)
    {
        var employee = await employeeRepository.GetByIdAsync(id) ?? 
                                throw new NotFoundException(nameof(Employee), id);

        await employeeRepository.RemoveAsync(employee);
    }

    public async Task AddAsync(EmployeeCreateDtoInput employeeCreateDtoInput)
    {
        var employee = new Employee
        {
            FirstName = employeeCreateDtoInput.FirstName.Trim(),
            LastName = employeeCreateDtoInput.LastName.Trim(),
            MiddleName = employeeCreateDtoInput.MiddleName?.Trim(),
        };

        await employeeRepository.AddAsync(employee);
    }
}