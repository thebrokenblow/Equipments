using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Services.Employees.Dto.Paged;
using Equipments.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class EmployeeRepository(EquipmentsDbContext context) : IEmployeeRepository
{
    public async Task<(List<EmployeePagedDtoOutput> Employees, int CountEmployee)> GetRangeAsync(int countSkip, int countTake)
    {
        var querybleEmployees = context.Employees.AsQueryable();

        var count = await querybleEmployees.CountAsync();

        var employees = await querybleEmployees
                                            .Skip(countSkip)
                                            .Take(countTake)
                                            .Select(employee => new EmployeePagedDtoOutput
                                            {
                                                Id = employee.Id,
                                                FirstName = employee.FirstName,
                                                LastName = employee.LastName,
                                                MiddleName = employee.MiddleName,
                                            })
                                            .AsNoTracking()
                                            .ToListAsync();

        return (employees, count);
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);

        return employee;
    }

    public async Task AddAsync(Employee employee)
    {
        await context.AddAsync(employee);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Employee employee)
    { 
        context.Remove(employee);
        await context.SaveChangesAsync();
    }
}