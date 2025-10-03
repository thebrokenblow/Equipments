using Equipments.Application.Common;
using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Domain.QueryModels.Employees;

namespace Equipments.Application.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository, 
    IEmployeeQueries employeeQueries) : IEmployeeService
{
    public async Task AddAsync(Employee employee)
    {
        employee.SurnameAndInitials = employee.SurnameAndInitials.Trim();
        employee.SubdivisionName = employee.SubdivisionName?.Trim();
        employee.Note = employee.Note?.Trim();

        await employeeRepository.AddAsync(employee);
    }

    public async Task RemoveByIdAsync(int id)
    {
        var employee = await employeeRepository.GetByIdAsync(id) ??
                            throw new NotFoundException(nameof(Employee), id);

        await employeeRepository.RemoveAsync(employee);
    }

    public async Task<List<EmployeeModel>> GetForSelectAsync()
    {
        var employees = await employeeQueries.GetForSelectAsync();

        return employees;
    }

    public async Task<PagedResult<EmployeeModel>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var countSkip = (pageNumber - 1) * pageSize;
        var (employees, countEmployee) = await employeeQueries.GetRangeAsync(countSkip, pageSize);

        var pagedEmployee = new PagedResult<EmployeeModel>(employees, countEmployee, pageNumber, pageSize);

        return pagedEmployee;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        var employee = await employeeRepository.GetByIdAsync(id) ??
                            throw new NotFoundException(nameof(Employee), id);

        return employee;
    }

    public async Task UpdateAsync(Employee employee)
    {
        await employeeRepository.UpdateAsync(employee);
    }
}