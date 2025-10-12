using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

/// <summary>
/// Предоставляет методы для работы с данными сотрудников в хранилище.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Получает сотрудника по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника.</param>
    /// <returns>Задача, результатом которой является сущность сотрудника или null если не найден.</returns>
    Task<Employee?> GetByIdAsync(int id);

    /// <summary>
    /// Добавляет нового сотрудника в хранилище.
    /// </summary>
    /// <param name="employee">Данные сотрудника для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(Employee employee);

    /// <summary>
    /// Удаляет сотрудника из хранилища.
    /// </summary>
    /// <param name="employee">Сущность сотрудника для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task RemoveAsync(Employee employee);

    /// <summary>
    /// Обновляет данные сотрудника в хранилище.
    /// </summary>
    /// <param name="employee">Обновленные данные сотрудника.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task UpdateAsync(Employee employee);

    /// <summary>
    /// Асинхронно проверяет существование сотрудника с указанным идентификатором в хранилище.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника для проверки.</param>
    /// <returns>Задача, результатом которой является true, если сотрудник существует, иначе - false.</returns>
    Task<bool> IsExistAsync(int id);
}