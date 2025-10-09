using Equipments.Application.Common;
using Equipments.Domain.Entities;
using Equipments.Domain.QueryModels.Employees;

namespace Equipments.Application.Services.Interfaces;

/// <summary>
/// Предоставляет методы для работы с сотрудниками в системе.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Добавляет нового сотрудника в систему.
    /// </summary>
    /// <param name="employee">Данные сотрудника для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(Employee employee);

    /// <summary>
    /// Удаляет сотрудника по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если сотрудник с указанным идентификатором не найден.</exception>
    Task RemoveByIdAsync(int id);

    /// <summary>
    /// Получает список сотрудников для выбора в выпадающих списках.
    /// </summary>
    /// <returns>Задача, результатом которой является список моделей сотрудников для выбора.</returns>
    Task<List<EmployeeModel>> GetForSelectAsync();

    /// <summary>
    /// Получает постраничный список сотрудников.
    /// </summary>
    /// <param name="pageNumber">Номер страницы (начинается с 1).</param>
    /// <param name="pageSize">Количество элементов на странице.</param>
    /// <returns>Задача, результатом которой является постраничный результат с моделями сотрудников.</returns>
    Task<PagedResult<EmployeeModel>> GetPagedAsync(int pageNumber, int pageSize);

    /// <summary>
    /// Получает сотрудника по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника.</param>
    /// <returns>Задача, результатом которой является сущность сотрудника.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если сотрудник с указанным идентификатором не найден.</exception>
    Task<Employee> GetByIdAsync(int id);

    /// <summary>
    /// Обновляет данные сотрудника.
    /// </summary>
    /// <param name="employee">Обновленные данные сотрудника.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если сотрудник не найден.</exception>
    Task UpdateAsync(Employee employee);
}