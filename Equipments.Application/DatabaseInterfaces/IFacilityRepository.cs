using Equipments.Application.Services.Facilities.Dto.GetAll;
using Equipments.Domain;

namespace Equipments.Application.DatabaseInterfaces;

public interface IFacilityRepository
{
    Task<List<FacilityGetAllDtoOutput>> GetAllAsync();
    Task AddAsync(Facility facility);
}