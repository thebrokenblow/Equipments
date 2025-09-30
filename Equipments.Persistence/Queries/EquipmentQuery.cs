using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.QueryModels.Equipments;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Queries;

public class EquipmentQuery(EquipmentsDbContext context) : IEquipmentQueries
{
    public async Task<(List<EquipmentListModel> Equipments, int CountEquipmentsWithFilter)> GetFilteredRangeAsync(
        int countSkip, 
        int countTake, 
        EquipmentFilterModel equipmentFilterModel)
    {
        var query = context.Equipments
                           .Include(equipment => equipment.Employee)
                           .Include(equipment => equipment.TypeEquipment)
                           .Where(equipment => equipment.FacilityId == equipmentFilterModel.FacilityId)
                           .AsQueryable();

        if (!string.IsNullOrEmpty(equipmentFilterModel.CabinetNumber))
        {
            query = query.Where(equipment => equipment.CabinetNumber.Contains(equipmentFilterModel.CabinetNumber));
        }

        if (!string.IsNullOrEmpty(equipmentFilterModel.SerialNumber))
        {
            query = query.Where(equipment => equipment.SerialNumber.Contains(equipmentFilterModel.SerialNumber));
        }

        var count = await query.CountAsync();

        var equipments = await query
                                .Skip(countSkip)
                                .Take(countTake)
                                .Select(equipment => new EquipmentListModel
                                {
                                    Id = equipment.Id,
                                    CabinetNumber = equipment.CabinetNumber,
                                    SerialNumber = equipment.SerialNumber,
                                    TypeEquipment = equipment.TypeEquipment == null ? string.Empty : equipment.TypeEquipment.Name,
                                    FirstName = equipment.Employee == null ? string.Empty : equipment.Employee.FirstName,
                                    LastName = equipment.Employee == null ? string.Empty : equipment.Employee.LastName,
                                    MiddleName = equipment.Employee == null ? string.Empty : equipment.Employee.MiddleName,
                                    ConclusionSpecialProject = equipment.ConclusionSpecialProject,
                                    ConclusionSpecResearch = equipment.ConclusionSpecResearch,
                                    Note = equipment.Note,
                                })
                                .AsNoTracking()
                                .ToListAsync();

        return (equipments, count);
    }
}