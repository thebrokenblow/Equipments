using Equipments.Application.Common;
using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Application.Services;

/// <summary>
/// Реализация сервиса для работы с оборудованием.
/// </summary>
/// <remarks>
/// Предоставляет бизнес-логику для управления оборудованием, включая валидацию, обработку данных и пагинацию.
/// </remarks>
/// <param name="equipmentRepository">Репозиторий для операций с данными оборудования</param>
/// <param name="equipmentQueries">Запросы для получения данных оборудования</param>
public class EquipmentService(
    IEquipmentRepository equipmentRepository,
    IEquipmentQueries equipmentQueries) : IEquipmentService
{
    /// <summary>
    /// Добавляет новое оборудование с предварительной обработкой данных.
    /// </summary>
    /// <remarks>
    /// Выполняет автоматическое обрезание пробелов в текстовых полях: SerialNumber, CabinetNumber, 
    /// ConclusionSpecResearch, ConclusionSpecialProject, Note.
    /// </remarks>
    /// <param name="equipment">Данные оборудования для добавления</param>
    public async Task AddAsync(Equipment equipment)
    {
        equipment.SerialNumber = equipment.SerialNumber.Trim();
        equipment.CabinetNumber = equipment.CabinetNumber.Trim();
        equipment.ConclusionSpecResearch = equipment.ConclusionSpecResearch?.Trim();
        equipment.ConclusionSpecialProject = equipment.ConclusionSpecialProject?.Trim();
        equipment.Note = equipment.Note?.Trim();

        await equipmentRepository.AddAsync(equipment);
    }

    /// <summary>
    /// Удаляет оборудование по идентификатору после проверки существования.
    /// </summary>
    /// <param name="id">Идентификатор оборудования для удаления</param>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование не найдено</exception>
    public async Task RemoveByIdAsync(int id)
    {
        var equipment = await equipmentRepository.GetByIdAsync(id) ??
                                throw new NotFoundException(nameof(Equipment), id);

        await equipmentRepository.RemoveAsync(equipment);
    }

    /// <summary>
    /// Обновляет данные оборудования с предварительной обработкой.
    /// </summary>
    /// <remarks>
    /// Выполняет автоматическое обрезание пробелов в текстовых полях перед обновлением.
    /// </remarks>
    /// <param name="equipment">Обновленные данные оборудования</param>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование не найдено</exception>
    public async Task UpdateAsync(Equipment equipment)
    {
        equipment.SerialNumber = equipment.SerialNumber.Trim();
        equipment.CabinetNumber = equipment.CabinetNumber.Trim();
        equipment.ConclusionSpecResearch = equipment.ConclusionSpecResearch?.Trim();
        equipment.ConclusionSpecialProject = equipment.ConclusionSpecialProject?.Trim();
        equipment.Note = equipment.Note?.Trim();

        await equipmentRepository.UpdateAsync(equipment);
    }

    /// <summary>
    /// Получает отфильтрованный постраничный список оборудования.
    /// </summary>
    /// <remarks>
    /// Выполняет предварительную обработку параметров фильтра (обрезка пробелов) и вычисляет смещение для пагинации.
    /// </remarks>
    /// <param name="pageNumber">Номер страницы (начинается с 1)</param>
    /// <param name="pageSize">Количество элементов на странице</param>
    /// <param name="equipmentFilterModel">Модель фильтра для поиска оборудования</param>
    /// <returns>Постраничный результат с отфильтрованным списком оборудования</returns>
    public async Task<PagedResult<EquipmentDetailsListModel>> GetFilteredPagedAsync(
        int pageNumber,
        int pageSize,
        EquipmentFilterModel equipmentFilterModel)
    {
        equipmentFilterModel.SerialNumber = equipmentFilterModel.SerialNumber?.Trim();
        equipmentFilterModel.CabinetNumber = equipmentFilterModel.CabinetNumber?.Trim();

        int countSkip = (pageNumber - 1) * pageSize;
        var equipmentsFilteredPage = await equipmentQueries.GetFilteredRangeAsync(countSkip, pageSize, equipmentFilterModel);

        var pagedEquipments = new PagedResult<EquipmentDetailsListModel>(
            equipmentsFilteredPage.Equipments,
            equipmentsFilteredPage.CountEquipmentsWithFilter,
            pageNumber,
            pageSize);

        return pagedEquipments;
    }

    /// <summary>
    /// Получает оборудование по идентификатору с проверкой существования.
    /// </summary>
    /// <param name="id">Идентификатор оборудования</param>
    /// <returns>Сущность оборудования</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование не найдено</exception>
    public async Task<Equipment> GetByIdAsync(int id)
    {
        var equipment = await equipmentRepository.GetByIdAsync(id) ??
                                throw new NotFoundException(nameof(Equipment), id);

        return equipment;
    }

    /// <summary>
    /// Получает детальную информацию об оборудовании по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор оборудования</param>
    /// <returns>Детальная модель оборудования</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если оборудование не найдено</exception>
    public async Task<EquipmentDetailsModel> GetDetailsByIdAsync(int id)
    {
        var equipment = await equipmentQueries.GetDetailsByIdAsync(id) ??
                                throw new NotFoundException(nameof(Equipment), id);

        return equipment;
    }

    /// <summary>
    /// Создает дубликат оборудования на основе существующего.
    /// </summary>
    /// <remarks>
    /// Копирует основные данные оборудования, кроме идентификатора. 
    /// Созданный дубликат имеет те же значения полей, что и исходное оборудование.
    /// </remarks>
    /// <param name="equipmentId">Идентификатор исходного оборудования для дублирования</param>
    /// <exception cref="NotFoundException">Выбрасывается, если исходное оборудование не найдено</exception>
    public async Task CreateDuplicateAsync(int equipmentId)
    {
        var equipment = await equipmentRepository.GetByIdAsync(equipmentId) ??
                                throw new NotFoundException(nameof(Equipment), equipmentId);

        var duplicateEquipment = new Equipment
        {
            SerialNumber = equipment.SerialNumber,
            CabinetNumber = equipment.CabinetNumber,
            TypeEquipmentId = equipment.TypeEquipmentId,
            EmployeeId = equipment.EmployeeId,
            ConclusionSpecialProject = equipment.ConclusionSpecialProject,
            ConclusionSpecResearch = equipment.ConclusionSpecResearch,
            Note = equipment.Note,
            FacilityId = equipment.FacilityId,
        };

        await equipmentRepository.AddAsync(duplicateEquipment);
    }
}