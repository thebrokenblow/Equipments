using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.QueryModels.Equipments;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Queries;

public class EquipmentQuery(EquipmentsDbContext context) : IEquipmentQueries
{
    public async Task<(List<EquipmentDetailsListModel> Equipments, int CountEquipmentsWithFilter)> GetFilteredRangeAsync(
        int countSkip, 
        int countTake, 
        EquipmentFilterModel equipmentFilterModel)
    {
        var equipmentsQuery = context.Equipments
                                        .Where(equipment => equipment.FacilityId == equipmentFilterModel.FacilityId);

        if (!string.IsNullOrEmpty(equipmentFilterModel.CabinetNumber))
        {
            equipmentsQuery = equipmentsQuery.Where(e => e.CabinetNumber.Contains(equipmentFilterModel.CabinetNumber));
        }

        if (!string.IsNullOrEmpty(equipmentFilterModel.SerialNumber))
        {
            equipmentsQuery = equipmentsQuery.Where(e => e.SerialNumber.Contains(equipmentFilterModel.SerialNumber));
        }

        var count = await equipmentsQuery.CountAsync();
        var equipments = await equipmentsQuery
                                    .OrderBy(equipment => equipment.SerialNumber)
                                    .Select(equipment => new EquipmentDetailsListModel
                                    {
                                        Id = equipment.Id,
                                        CabinetNumber = equipment.CabinetNumber,
                                        SerialNumber = equipment.SerialNumber,
                                        TypeEquipment = equipment.TypeEquipment!.Name,
                                        SurnameAndInitials = equipment.Employee!.SurnameAndInitials,
                                        ConclusionSpecialProject = equipment.ConclusionSpecialProject,
                                        ConclusionSpecResearch = equipment.ConclusionSpecResearch,
                                        Note = equipment.Note,
                                    })
                                    .Skip(countSkip)
                                    .Take(countTake)
                                    .AsNoTracking()
                                    .ToListAsync();

        return (equipments, count);
    }

    public async Task<EquipmentDetailsModel?> GetDetailsByIdAsync(int id)
    {
        var equipment = await context.Equipments
                                        .Where(equipment => equipment.Id == id)
                                        .Select(equipment => new EquipmentDetailsModel
                                        {
                                            Id = equipment.Id,
                                            CabinetNumber = equipment.CabinetNumber,
                                            SerialNumber = equipment.SerialNumber,
                                            TypeEquipment = equipment.TypeEquipment!.Name,
                                            SurnameAndInitials = equipment.Employee!.SurnameAndInitials,
                                            ConclusionSpecialProject = equipment.ConclusionSpecialProject,
                                            ConclusionSpecResearch = equipment.ConclusionSpecResearch,
                                            Note = equipment.Note,
                                            FacilityId = equipment.Facility!.Id,
                                            FacilityName = equipment.Facility!.Name,
                                        })
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();

        return equipment;
    }
}