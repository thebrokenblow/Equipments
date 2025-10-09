using Equipments.Application.Common;
using Equipments.Domain.Entities;
using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Application.Services.Interfaces;

/// <summary>
/// Предоставляет методы для работы с оборудованием в системе.
/// </summary>
public interface IEquipmentService
{
    /// <summary>
    /// Добавляет новое оборудование в систему.
    /// </summary>
    /// <param name="equipment">Данные оборудования для добавления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task AddAsync(Equipment equipment);

    /// <summary>
    /// Удаляет оборудование по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор оборудования для удаления.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование с указанным идентификатором не найдено.</exception>
    Task RemoveByIdAsync(int id);

    /// <summary>
    /// Обновляет данные оборудования.
    /// </summary>
    /// <param name="equipment">Обновленные данные оборудования.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование не найдено.</exception>
    Task UpdateAsync(Equipment equipment);

    /// <summary>
    /// Получает оборудование по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор оборудования.</param>
    /// <returns>Задача, результатом которой является сущность оборудования.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование с указанным идентификатором не найдено.</exception>
    Task<Equipment> GetByIdAsync(int id);

    /// <summary>
    /// Получает детальную информацию об оборудовании по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор оборудования.</param>
    /// <returns>Задача, результатом которой является детальная модель оборудования.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование с указанным идентификатором не найдено.</exception>
    Task<EquipmentDetailsModel> GetDetailsByIdAsync(int id);

    /// <summary>
    /// Получает отфильтрованный постраничный список оборудования.
    /// </summary>
    /// <param name="pageNumber">Номер страницы (начинается с 1).</param>
    /// <param name="pageSize">Количество элементов на странице.</param>
    /// <param name="equipmentFilterModel">Модель фильтра для поиска и фильтрации оборудования.</param>
    /// <returns>Задача, результатом которой является постраничный результат с отфильтрованным списком оборудования.</returns>
    Task<PagedResult<EquipmentDetailsListModel>> GetFilteredPagedAsync(
        int pageNumber,
        int pageSize,
        EquipmentFilterModel equipmentFilterModel);

    /// <summary>
    /// Создает дубликат оборудования на основе существующего.
    /// </summary>
    /// <param name="id">Идентификатор исходного оборудования для дублирования.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если исходное оборудование не найдено.</exception>
    Task CreateDuplicateAsync(int id);
}