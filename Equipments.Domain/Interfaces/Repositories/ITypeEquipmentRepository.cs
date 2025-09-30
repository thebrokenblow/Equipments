using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

public interface ITypeEquipmentRepository
{
    Task<List<TypeEquipment>> GetAllAsync();
    Task AddAsync(TypeEquipment typeEquipment);
}