using Equipments.Application.Services.Facilities.Dto.Create;
using Equipments.Application.Services.Facilities.Dto.GetAll;

namespace Equipments.Application.Services.Facilities;

public interface IFacilitiesService
{
    Task<List<FacilityGetAllDtoOutput>> GelAllAsync();
    Task AddAsync(FacilityCreateDtoInput facilityCreateDtoInput);
}