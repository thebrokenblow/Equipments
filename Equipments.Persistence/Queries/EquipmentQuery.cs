using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.QueryModels.Equipments;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Queries;

/// <summary>
/// Реализация запросов для работы с данными оборудования
/// </summary>
public class EquipmentQuery(EquipmentsDbContext context) : IEquipmentQueries
{
    /// <summary>
    /// Получает отфильтрованный диапазон оборудования с количеством
    /// </summary>
    /// <param name="countSkip">Количество пропускаемых записей</param>
    /// <param name="countTake">Количество получаемых записей</param>
    /// <param name="equipmentFilterModel">Модель фильтра для поиска оборудования</param>
    /// <returns>Задача, результатом которой является кортеж содержащий список оборудования и количество с учетом фильтра</returns>
    public async Task<(List<EquipmentDetailsListModel> Equipments, int CountEquipmentsWithFilter)> GetFilteredRangeAsync(
        int countSkip,
        int countTake,
        EquipmentFilterModel equipmentFilterModel)
    {
        var equipmentsQuery = context.Equipments
                                        .Where(equipment => equipment.FacilityId == equipmentFilterModel.FacilityId)
                                        .AsNoTracking();

        if (!string.IsNullOrEmpty(equipmentFilterModel.CabinetNumber))
        {
            equipmentsQuery = equipmentsQuery.Where(e => e.CabinetNumber.Contains(equipmentFilterModel.CabinetNumber));
        }

        if (!string.IsNullOrEmpty(equipmentFilterModel.SerialNumber))
        {
            equipmentsQuery = equipmentsQuery.Where(e => e.SerialNumber.Contains(equipmentFilterModel.SerialNumber));
        }

        var rangeEquipmentsQuery = equipmentsQuery
                                        .OrderBy(equipment => equipment.CabinetNumber)
                                        .ThenBy(equipment => equipment.TypeEquipment!.Name)
                                        .Skip(countSkip)
                                        .Take(countTake);

        var count = await equipmentsQuery.CountAsync();
        var equipments = await rangeEquipmentsQuery
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
                                    .ToListAsync();

        return (equipments, count);
    }

    /// <summary>
    /// Получает детальную информацию об оборудовании по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор оборудования</param>
    /// <returns>Задача, результатом которой является детальная модель оборудования или null если не найдено</returns>
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