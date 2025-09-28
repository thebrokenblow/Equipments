using Equipments.Application.DatabaseInterfaces;
using Equipments.Domain;

namespace Equipments.Persistence.Repositories;

public class TypeEquipmentRepository(EquipmentsDbContext equipmentsDbContext) : ITypeEquipmentRepository
{
    public async Task AddAsync(TypeEquipment typeEquipment)
    {
        await equipmentsDbContext.AddAsync(typeEquipment);
        await equipmentsDbContext.SaveChangesAsync();
    }
}