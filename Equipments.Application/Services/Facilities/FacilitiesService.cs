using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Services.Facilities.Dto.Create;
using Equipments.Application.Services.Facilities.Dto.GetAll;
using Equipments.Domain;

namespace Equipments.Application.Services.Facilities;

public class FacilitiesService(IFacilityRepository facilityRepository) : IFacilitiesService
{
    public async Task<List<FacilityGetAllDtoOutput>> GelAllAsync()
    {
        var facilities = await facilityRepository.GetAllAsync();

        return facilities;
    }

    public async Task AddAsync(FacilityCreateDtoInput facilityCreateDtoInput)
    {
        facilityCreateDtoInput.Name = facilityCreateDtoInput.Name.Trim();

        var facility = new Facility
        {
            Name  = facilityCreateDtoInput.Name,
        };

        await facilityRepository.AddAsync(facility);
    }
}
