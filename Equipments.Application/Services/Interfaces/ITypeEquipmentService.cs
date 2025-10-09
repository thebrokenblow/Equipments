using Equipments.Domain.Entities;

namespace Equipments.Application.Services.Interfaces;

/// <summary>
/// Предоставляет методы для работы с типами оборудования в системе.
/// </summary>
public interface ITypeEquipmentService
{
    /// <summary>
    /// Добавляет новый тип оборудования в систему.
    /// </summary>
    /// <param name="typeEquipment">Данные типа оборудования для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(TypeEquipment typeEquipment);

    /// <summary>
    /// Получает список всех типов оборудования.
    /// </summary>
    /// <returns>Задача, результатом которой является список всех типов оборудования.</returns>
    Task<List<TypeEquipment>> GetAllAsync();

    /// <summary>
    /// Получает тип оборудования по указанному идентификатору.
    /// </summary>
    /// <param name="typeEquipmentId">Идентификатор типа оборудования.</param>
    /// <returns>Задача, результатом которой является сущность типа оборудования.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если тип оборудования с указанным идентификатором не найден.</exception>
    Task<TypeEquipment> GetByIdAsync(int typeEquipmentId);

    /// <summary>
    /// Обновляет данные типа оборудования.
    /// </summary>
    /// <param name="typeEquipment">Обновленные данные типа оборудования.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если тип оборудования не найден.</exception>
    Task UpdateAsync(TypeEquipment typeEquipment);
}