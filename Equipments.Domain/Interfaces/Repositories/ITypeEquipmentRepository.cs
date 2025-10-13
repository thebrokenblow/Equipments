using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

/// <summary>
/// Предоставляет методы для работы с данными типов оборудования в хранилище.
/// </summary>
public interface ITypeEquipmentRepository
{
    /// <summary>
    /// Получает список всех типов оборудования.
    /// </summary>
    /// <returns>Задача, результатом которой является список всех типов оборудования.</returns>
    Task<List<TypeEquipment>> GetAllAsync();

    /// <summary>
    /// Получает тип оборудования по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор типа оборудования.</param>
    /// <returns>Задача, результатом которой является сущность типа оборудования или null если не найден.</returns>
    Task<TypeEquipment?> GetByIdAsync(int id);

    /// <summary>
    /// Добавляет новый тип оборудования в хранилище.
    /// </summary>
    /// <param name="typeEquipment">Данные типа оборудования для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(TypeEquipment typeEquipment);

    /// <summary>
    /// Обновляет данные типа оборудования в хранилище.
    /// </summary>
    /// <param name="typeEquipment">Обновленные данные типа оборудования.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task UpdateAsync(TypeEquipment typeEquipment);
}