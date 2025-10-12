using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

/// <summary>
/// Реализация репозитория для работы с данными типов оборудования
/// </summary>
public class TypeEquipmentRepository(EquipmentsDbContext context) : ITypeEquipmentRepository
{
    /// <summary>
    /// Получает список всех типов оборудования
    /// </summary>
    /// <returns>Задача, результатом которой является список всех типов оборудования</returns>
    public async Task<List<TypeEquipment>> GetAllAsync()
    {
        var typesEquipments = await context.TypeEquipments
                                                .OrderBy(typeEquipment => typeEquipment.Name)
                                                .AsNoTracking()
                                                .ToListAsync();
        return typesEquipments;
    }

    /// <summary>
    /// Получает тип оборудования по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор типа оборудования</param>
    /// <returns>Задача, результатом которой является сущность типа оборудования или null если не найден</returns>
    public Task<TypeEquipment?> GetByIdAsync(int id)
    {
        var typeEquipment = context.TypeEquipments
                                             .AsNoTracking()
                                             .FirstOrDefaultAsync(typeEquipment => typeEquipment.Id == id);
        return typeEquipment;
    }

    /// <summary>
    /// Добавляет новый тип оборудования в хранилище
    /// </summary>
    /// <param name="typeEquipment">Данные типа оборудования для добавления</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task AddAsync(TypeEquipment typeEquipment)
    {
        await context.AddAsync(typeEquipment);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Обновляет данные типа оборудования в хранилище
    /// </summary>
    /// <param name="typeEquipment">Обновленные данные типа оборудования</param>
    /// <returns>Задача, представляющая асинхронную операцию</returns>
    public async Task UpdateAsync(TypeEquipment typeEquipment)
    {
        context.Update(typeEquipment);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Асинхронно проверяет существование типа оборудования с указанным идентификатором в хранилище
    /// </summary>
    /// <param name="id">Идентификатор типа оборудования для проверки</param>
    /// <returns>Задача, результатом которой является true, если тип оборудования существует, иначе - false</returns>
    public async Task<bool> IsExistAsync(int id)
    {
        var isExist = await context.TypeEquipments.AnyAsync(typeEquipment => typeEquipment.Id == id);

        return isExist;
    }
}