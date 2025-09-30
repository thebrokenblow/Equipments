using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

public interface IFacilityRepository
{
    Task<List<Facility>> GetAllAsync();
    Task AddAsync(Facility facility);
}