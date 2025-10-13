using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

/// <summary>
/// Предоставляет методы для работы с данными объектов в хранилище.
/// </summary>
public interface IFacilityRepository
{
    /// <summary>
    /// Получает список всех объектов.
    /// </summary>
    /// <returns>Задача, результатом которой является список всех объектов.</returns>
    Task<List<Facility>> GetAllAsync();

    /// <summary>
    /// Добавляет новый объект в хранилище.
    /// </summary>
    /// <param name="facility">Данные объекта для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(Facility facility);

    /// <summary>
    /// Получает объект по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор объекта.</param>
    /// <returns>Задача, результатом которой является сущность объекта или null если не найден.</returns>
    Task<Facility?> GetByIdAsync(int id);

    /// <summary>
    /// Обновляет данные объекта в хранилище.
    /// </summary>
    /// <param name="facility">Обновленные данные объекта.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task UpdateAsync(Facility facility);

    /// <summary>
    /// Удаляет объект из хранилища.
    /// </summary>
    /// <param name="facility">Сущность объекта для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task RemoveAsync(Facility facility);
}