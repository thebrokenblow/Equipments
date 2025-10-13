using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;

namespace Equipments.Application.Services;

/// <summary>
/// Реализация сервиса для работы с объектами (facilities).
/// </summary>
/// <remarks>
/// Предоставляет бизнес-логику для управления объектами, включая валидацию и базовые CRUD операции.
/// </remarks>
/// <param name="facilityRepository">Репозиторий для операций с данными объектов</param>
public class FacilityService(IFacilityRepository facilityRepository) : IFacilityService
{
    /// <summary>
    /// Добавляет новый объект с предварительной обработкой данных.
    /// </summary>
    /// <remarks>
    /// Выполняет автоматическое обрезание пробелов в поле Name перед сохранением.
    /// </remarks>
    /// <param name="facility">Данные объекта для добавления</param>
    public async Task AddAsync(Facility facility)
    {
        facility.Name = facility.Name.Trim();
        await facilityRepository.AddAsync(facility);
    }

    /// <summary>
    /// Получает список всех объектов.
    /// </summary>
    /// <returns>Список всех объектов в системе</returns>
    public async Task<List<Facility>> GetAllAsync()
    {
        var facilities = await facilityRepository.GetAllAsync();
        return facilities;
    }

    /// <summary>
    /// Получает объект по идентификатору с проверкой существования.
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Сущность объекта</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если объект с указанным идентификатором не найден</exception>
    public async Task<Facility> GetByIdAsync(int id)
    {
        var facility = await facilityRepository.GetByIdAsync(id) ??
                                throw new NotFoundException(nameof(Facility), id);

        return facility;
    }

    /// <summary>
    /// Удаляет объект по идентификатору.
    /// </summary>
    /// <remarks>
    /// Перед удалением проверяет существование объекта через метод GetByIdAsync.
    /// </remarks>
    /// <param name="id">Идентификатор объекта для удаления</param>
    /// <exception cref="NotFoundException">Выбрасывается, если объект не найден</exception>
    public async Task RemoveByIdAsync(int id)
    {
        var facility = await GetByIdAsync(id);
        await facilityRepository.RemoveAsync(facility);
    }

    /// <summary>
    /// Обновляет данные объекта.
    /// </summary>
    /// <param name="facility">Обновленные данные объекта</param>
    /// <exception cref="NotFoundException">Выбрасывается, если объект не найден</exception>
    public async Task UpdateAsync(Facility facility)
    {
        await facilityRepository.UpdateAsync(facility);
    }
}