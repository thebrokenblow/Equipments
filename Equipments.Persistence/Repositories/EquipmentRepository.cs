using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class EquipmentRepository(EquipmentsDbContext context) : IEquipmentRepository
{
    public async Task<Equipment?> GetByIdAsync(int id)
    {
        var equipment = await context.Equipments.FirstOrDefaultAsync(equipment => equipment.Id == id);

        return equipment;
    }

    public async Task AddAsync(Equipment equipment)
    {
        await context.AddAsync(equipment);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Equipment equipment)
    {
        context.Update(equipment);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Equipment equipment)
    {
        context.Remove(equipment);
        await context.SaveChangesAsync();
    }
}