using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.QueryModels.Employees;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Queries;

public class EmployeeQuery(EquipmentsDbContext context) : IEmployeeQueries
{
    public async Task<List<EmployeeModel>> GetForSelectAsync()
    {
        var employees = await context.Employees.Select(
                                                    employee => new EmployeeModel
                                                    {
                                                        Id = employee.Id,
                                                        FirstName = employee.FirstName,
                                                        LastName = employee.LastName,
                                                        MiddleName = employee.MiddleName
                                                    }).ToListAsync();

        return employees;
    }

    public async Task<(List<EmployeeModel> Employees, int CountAllEmployees)> GetRangeAsync(int countSkip, int countTake)
    {
        var querybleEmployees = context.Employees.AsQueryable();

        var count = await querybleEmployees.CountAsync();

        var employees = await querybleEmployees
                                            .Skip(countSkip)
                                            .Take(countTake)
                                            .Select(employee => new EmployeeModel
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
}
