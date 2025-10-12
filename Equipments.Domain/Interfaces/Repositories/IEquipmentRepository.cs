using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

/// <summary>
/// Предоставляет методы для работы с данными оборудования в хранилище.
/// </summary>
public interface IEquipmentRepository
{
    /// <summary>
    /// Получает оборудование по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор оборудования.</param>
    /// <returns>Задача, результатом которой является сущность оборудования или null если не найдено.</returns>
    Task<Equipment?> GetByIdAsync(int id);

    /// <summary>
    /// Добавляет новое оборудование в хранилище.
    /// </summary>
    /// <param name="equipment">Данные оборудования для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(Equipment equipment);

    /// <summary>
    /// Удаляет оборудование из хранилище.
    /// </summary>
    /// <param name="equipment">Сущность оборудования для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task RemoveAsync(Equipment equipment);

    /// <summary>
    /// Обновляет данные оборудования в хранилище.
    /// </summary>
    /// <param name="equipment">Обновленные данные оборудования.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task UpdateAsync(Equipment equipment);

    /// <summary>
    /// Асинхронно проверяет существование оборудования с указанным идентификатором в хранилище.
    /// </summary>
    /// <param name="id">Идентификатор оборудования для проверки.</param>
    /// <returns>Задача, результатом которой является true, если оборудование существует, иначе - false.</returns>
    Task<bool> IsExistAsync(int id);
}