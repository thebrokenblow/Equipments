using Equipments.Domain.Entities;

namespace Equipments.Application.Services.Interfaces;

public interface IFacilityService
{
    Task AddAsync(Facility facility);
    Task<List<Facility>> GetAllAsync();
}