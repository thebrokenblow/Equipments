using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class TypeEquipmentRepository(EquipmentsDbContext equipmentsDbContext) : ITypeEquipmentRepository
{
    public async Task<List<TypeEquipment>> GetAllAsync()
    {
        var typesEquipments = await equipmentsDbContext.TypeEquipments.ToListAsync();

        return typesEquipments;
    }

    public async Task AddAsync(TypeEquipment typeEquipment)
    {
        await equipmentsDbContext.AddAsync(typeEquipment);
        await equipmentsDbContext.SaveChangesAsync();
    }
}