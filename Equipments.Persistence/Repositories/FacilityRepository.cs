using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class FacilityRepository(EquipmentsDbContext context) : IFacilityRepository
{
    public async Task<List<Facility>> GetAllAsync()
    {
        var facilities = await context.Facilities.ToListAsync();

        return facilities;
    }

    public async Task AddAsync(Facility facility)
    {
        await context.AddAsync(facility);
        await context.SaveChangesAsync();
    }
}