using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

public interface IEquipmentRepository
{
    Task<Equipment?> GetByIdAsync(int id);
    Task AddAsync(Equipment equipment);
    Task RemoveAsync(Equipment equipment);
    Task UpdateAsync(Equipment equipment);
}