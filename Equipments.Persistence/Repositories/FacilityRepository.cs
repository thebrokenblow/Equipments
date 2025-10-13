using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

/// <summary>
/// Реализация репозитория для работы с данными объектов
/// </summary>
public class FacilityRepository(EquipmentsDbContext context) : IFacilityRepository
{
    /// <summary>
    /// Получает список всех объектов
    /// </summary>
    /// <returns>Задача, результатом которой является список всех объектов</returns>
    public async Task<List<Facility>> GetAllAsync()
    {
        var facilities = await context.Facilities.ToListAsync();
        return facilities;
    }

    /// <summary>
    /// Добавляет новый объект в хранилище
    /// </summary>
    /// <param name="facility">Данные объекта для добавления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task AddAsync(Facility facility)
    {
        await context.AddAsync(facility);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Получает объект по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор объекта</param>
    /// <returns>Задача, результатом которой является сущность объекта или null если не найден</returns>
    public async Task<Facility?> GetByIdAsync(int id)
    {
        var facility = await context.Facilities.FirstOrDefaultAsync(facility => facility.Id == id);
        return facility;
    }

    /// <summary>
    /// Обновляет данные объекта в хранилище
    /// </summary>
    /// <param name="facility">Обновленные данные объекта</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task UpdateAsync(Facility facility)
    {
        context.Update(facility);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаляет объект из хранилища
    /// </summary>
    /// <param name="facility">Сущность объекта для удаления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task RemoveAsync(Facility facility)
    {
        context.Remove(facility);
        await context.SaveChangesAsync();
    }
}