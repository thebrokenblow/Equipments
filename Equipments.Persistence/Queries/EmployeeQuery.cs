using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.QueryModels.Employees;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Queries;

/// <summary>
/// Реализация запросов для работы с данными сотрудников
/// </summary>
public class EmployeeQuery(EquipmentsDbContext context) : IEmployeeQueries
{
    /// <summary>
    /// Получает список сотрудников для выбора в выпадающих списках
    /// </summary>
    /// <returns>Задача, результатом которой является список моделей сотрудников для выбора</returns>
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
                                .OrderBy(employee => employee.SurnameAndInitials)
                                .AsNoTracking()
                                .ToListAsync();
    }

    /// <summary>
    /// Получает диапазон сотрудников с общим количеством
    /// </summary>
    /// <param name="countSkip">Количество пропускаемых записей</param>
    /// <param name="countTake">Количество получаемых записей</param>
    /// <returns>Задача, результатом которой является кортеж содержащий список сотрудников и общее количество</returns>
    public async Task<(List<EmployeeModel> Employees, int CountAllEmployees)> GetRangeAsync(int countSkip, int countTake)
    {
        var count = await context.Employees.CountAsync();

        var employees = await context.Employees
                                        .OrderBy(employee => employee.SubdivisionName)
                                        .ThenBy(employee => employee.SurnameAndInitials)
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