using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.QueryModels.Employees;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Queries;

public class EmployeeQuery(EquipmentsDbContext context) : IEmployeeQueries
{
    public async Task<List<EmployeeModel>> GetForSelectAsync()
    {
        return await context.Employees
                                .Select(employee => new EmployeeModel
                                {
                                    Id = employee.Id,
                                    SurnameAndInitials = employee.SurnameAndInitials,
                                    SubdivisionName = employee.SubdivisionName,
                                    Note = employee.Note
                                })
                                .AsNoTracking()
                                .ToListAsync();
    }

    public async Task<(List<EmployeeModel> Employees, int CountAllEmployees)> GetRangeAsync(int countSkip, int countTake)
    {
        var count = await context.Employees.CountAsync();

        var employees = await context.Employees
                                        .Skip(countSkip)
                                        .Take(countTake)
                                        .Select(employee => new EmployeeModel
                                        {
                                            Id = employee.Id,
                                            SurnameAndInitials = employee.SurnameAndInitials,
                                            SubdivisionName = employee.SubdivisionName,
                                            Note = employee.Note
                                        })
                                        .AsNoTracking()
                                        .ToListAsync();

        return (employees, count);
    }
}