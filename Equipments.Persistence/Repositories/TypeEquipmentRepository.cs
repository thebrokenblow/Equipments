using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class TypeEquipmentRepository(EquipmentsDbContext equipmentsDbContext) : ITypeEquipmentRepository
{
    public async Task<List<TypeEquipment>> GetAllAsync()
    {
        var typesEquipments = await equipmentsDbContext.TypeEquipments
                                                            .OrderBy(typeEquipment => typeEquipment.Name)
                                                            .AsNoTracking()
                                                            .ToListAsync();

        return typesEquipments;
    }

    public Task<TypeEquipment?> GetByIdAsync(int typeEquipmentId)
    {
        var typeEquipment = equipmentsDbContext.TypeEquipments
                                                    .AsNoTracking()
                                                    .FirstOrDefaultAsync(typeEquipment => typeEquipment.Id == typeEquipmentId);

        return typeEquipment;
    }

    public async Task AddAsync(TypeEquipment typeEquipment)
    {
        await equipmentsDbContext.AddAsync(typeEquipment);
        await equipmentsDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TypeEquipment typeEquipment)
    {
        equipmentsDbContext.Update(typeEquipment);
        await equipmentsDbContext.SaveChangesAsync();
    }
}