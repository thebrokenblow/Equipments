using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Services.Facilities.Dto.GetAll;
using Equipments.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class FacilityRepository(EquipmentsDbContext context) : IFacilityRepository
{
    public async Task<List<FacilityGetAllDtoOutput>> GetAllAsync()
    {
        var facilities = await context.Facilities.Select(facility => new FacilityGetAllDtoOutput 
                                                   {
                                                        Id = facility.Id,
                                                        Name = facility.Name,
                                                   })
                                                   .AsNoTracking()
                                                   .ToListAsync();

        return facilities;
    }

    public async Task AddAsync(Facility facility)
    {
        await context.AddAsync(facility);
        await context.SaveChangesAsync();
    }
}