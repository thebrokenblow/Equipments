using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;

namespace Equipments.Application.Services;

/// <summary>
/// Реализация сервиса для работы с типами оборудования.
/// </summary>
/// <remarks>
/// Предоставляет бизнес-логику для управления типами оборудования, включая валидацию и базовые CRUD операции.
/// </remarks>
/// <param name="typeEquipmentRepository">Репозиторий для операций с данными типов оборудования</param>
public class TypeEquipmentService(ITypeEquipmentRepository typeEquipmentRepository) : ITypeEquipmentService
{
    /// <summary>
    /// Добавляет новый тип оборудования с предварительной обработкой данных.
    /// </summary>
    /// <remarks>
    /// Выполняет автоматическое обрезание пробелов в поле Name перед сохранением.
    /// </remarks>
    /// <param name="typeEquipment">Данные типа оборудования для добавления</param>
    public async Task AddAsync(TypeEquipment typeEquipment)
    {
        typeEquipment.Name = typeEquipment.Name.Trim();
        await typeEquipmentRepository.AddAsync(typeEquipment);
    }

    /// <summary>
    /// Получает список всех типов оборудования.
    /// </summary>
    /// <returns>Список всех типов оборудования в системе</returns>
    public async Task<List<TypeEquipment>> GetAllAsync()
    {
        var typesEquipments = await typeEquipmentRepository.GetAllAsync();
        return typesEquipments;
    }

    /// <summary>
    /// Получает тип оборудования по идентификатору с проверкой существования.
    /// </summary>
    /// <param name="typeEquipmentId">Идентификатор типа оборудования</param>
    /// <returns>Сущность типа оборудования</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если тип оборудования с указанным идентификатором не найден</exception>
    public async Task<TypeEquipment> GetByIdAsync(int typeEquipmentId)
    {
        var typeEquipment = await typeEquipmentRepository.GetByIdAsync(typeEquipmentId) ??
                                throw new NotFoundException(nameof(TypeEquipment), typeEquipmentId);

        return typeEquipment;
    }

    /// <summary>
    /// Обновляет данные типа оборудования с предварительной обработкой.
    /// </summary>
    /// <remarks>
    /// Выполняет автоматическое обрезание пробелов в поле Name перед обновлением.
    /// </remarks>
    /// <param name="typeEquipment">Обновленные данные типа оборудования</param>
    /// <exception cref="NotFoundException">Выбрасывается, если тип оборудования не найден</exception>
    public async Task UpdateAsync(TypeEquipment typeEquipment)
    {
        var isExist = await typeEquipmentRepository.IsExistAsync(typeEquipment.Id);

        if (!isExist)
        {
            throw new NotFoundException(nameof(TypeEquipment), typeEquipment.Id);
        }

        typeEquipment.Name = typeEquipment.Name.Trim();

        await typeEquipmentRepository.UpdateAsync(typeEquipment);
    }
}