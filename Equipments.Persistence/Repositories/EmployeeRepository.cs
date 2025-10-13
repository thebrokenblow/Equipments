using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

/// <summary>
/// Реализация репозитория для работы с данными сотрудников
/// </summary>
public class EmployeeRepository(EquipmentsDbContext context) : IEmployeeRepository
{
    /// <summary>
    /// Получает сотрудника по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns>Задача, результатом которой является сущность сотрудника или null если не найден</returns>
    public async Task<Employee?> GetByIdAsync(int id)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
        return employee;
    }

    /// <summary>
    /// Добавляет нового сотрудника в хранилище
    /// </summary>
    /// <param name="employee">Данные сотрудника для добавления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task AddAsync(Employee employee)
    {
        await context.AddAsync(employee);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаляет сотрудника из хранилища
    /// </summary>
    /// <param name="employee">Сущность сотрудника для удаления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task RemoveAsync(Employee employee)
    {
        context.Remove(employee);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Обновляет данные сотрудника в хранилище
    /// </summary>
    /// <param name="employee">Обновленные данные сотрудника</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task UpdateAsync(Employee employee)
    {
        context.Update(employee);
        await context.SaveChangesAsync();
    }
}