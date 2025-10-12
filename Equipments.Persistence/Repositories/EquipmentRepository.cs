using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

/// <summary>
/// Реализация репозитория для работы с данными оборудования
/// </summary>
public class EquipmentRepository(EquipmentsDbContext context) : IEquipmentRepository
{
    /// <summary>
    /// Получает оборудование по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор оборудования</param>
    /// <returns>Задача, результатом которой является сущность оборудования или null если не найдено</returns>
    public async Task<Equipment?> GetByIdAsync(int id)
    {
        var equipment = await context.Equipments.FirstOrDefaultAsync(equipment => equipment.Id == id);
        return equipment;
    }

    /// <summary>
    /// Добавляет новое оборудование в хранилище
    /// </summary>
    /// <param name="equipment">Данные оборудования для добавления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task AddAsync(Equipment equipment)
    {
        await context.AddAsync(equipment);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Обновляет данные оборудования в хранилище
    /// </summary>
    /// <param name="equipment">Обновленные данные оборудования</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task UpdateAsync(Equipment equipment)
    {
        context.Update(equipment);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Удаляет оборудование из хранилища
    /// </summary>
    /// <param name="equipment">Сущность оборудования для удаления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task RemoveAsync(Equipment equipment)
    {
        context.Remove(equipment);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно проверяет существование оборудования с указанным идентификатором в хранилище
    /// </summary>
    /// <param name="id">Идентификатор оборудования для проверки</param>
    /// <returns>Задача, результатом которой является true, если оборудование существует, иначе - false</returns>
    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await context.Equipments.AnyAsync(equipment => equipment.Id == id);

        return isExist;
    }
}