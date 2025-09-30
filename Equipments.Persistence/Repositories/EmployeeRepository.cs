using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class EmployeeRepository(EquipmentsDbContext context) : IEmployeeRepository
{
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