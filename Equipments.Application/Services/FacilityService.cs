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
}