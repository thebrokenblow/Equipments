using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

public interface ITypeEquipmentRepository
{
    Task<List<TypeEquipment>> GetAllAsync();
    Task<TypeEquipment?> GetByIdAsync(int typeEquipmentId);
    Task AddAsync(TypeEquipment typeEquipment);
    Task UpdateAsync(TypeEquipment typeEquipment);
}