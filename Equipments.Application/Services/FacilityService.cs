using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;

namespace Equipments.Application.Services;

public class FacilityService(IFacilityRepository facilityRepository) : IFacilityService
{
    public async Task AddAsync(Facility facility)
    {
        facility.Name = facility.Name.Trim();

        await facilityRepository.AddAsync(facility);
    }

    public async Task<List<Facility>> GetAllAsync()
    {
        var facilities = await facilityRepository.GetAllAsync();

        return facilities;
    }

    public async Task<Facility> GetByIdAsync(int facilityId)
    {
        var facility = await facilityRepository.GetByIdAsync(facilityId) ?? 
                                throw new NotFoundException(nameof(Equipment), facilityId);

        return facility;
    }

    public async Task RemoveByIdAsync(int facilityId)
    {
        var facility = await GetByIdAsync(facilityId);
        await facilityRepository.RemoveAsync(facility);
    }

    public async Task UpdateAsync(Facility facility)
    {
        await facilityRepository.UpdateAsync(facility);
    }
}