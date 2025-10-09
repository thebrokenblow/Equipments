using Equipments.Domain.Entities;

namespace Equipments.Application.Services.Interfaces;

/// <summary>
/// Предоставляет методы для работы с объектами (facilities) в системе.
/// </summary>
public interface IFacilityService
{
    /// <summary>
    /// Добавляет новый объект в систему.
    /// </summary>
    /// <param name="facility">Данные объекта для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(Facility facility);

    /// <summary>
    /// Получает список всех объектов.
    /// </summary>
    /// <returns>Задача, результатом которой является список всех объектов.</returns>
    Task<List<Facility>> GetAllAsync();

    /// <summary>
    /// Получает объект по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    /// <returns>Задача, результатом которой является сущность объекта.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если объект с указанным идентификатором не найден.</exception>
    Task<Facility> GetByIdAsync(int id);

    /// <summary>
    /// Удаляет объект по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объекта для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если объект с указанным идентификатором не найден.</exception>
    Task RemoveByIdAsync(int id);

    /// <summary>
    /// Обновляет данные объекта.
    /// </summary>
    /// <param name="facility">Обновленные данные объекта.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если объект не найден.</exception>
    Task UpdateAsync(Facility facility);
}