using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

public interface IFacilityRepository
{
    Task<List<Facility>> GetAllAsync();
    Task AddAsync(Facility facility);
    Task<Facility?> GetByIdAsync(int id);
    Task UpdateAsync(Facility facility);
    Task RemoveAsync(Facility facility);
}