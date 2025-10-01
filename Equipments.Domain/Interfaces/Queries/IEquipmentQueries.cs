using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Domain.Interfaces.Queries;

public interface IEquipmentQueries
{
    Task<(List<EquipmentDetailsListModel> Equipments, int CountEquipmentsWithFilter)> GetFilteredRangeAsync(
        int countSkip, 
        int countTake, 
        EquipmentFilterModel equipmentFilterModel);
    Task<EquipmentDetailsModel?> GetDetailsByIdAsync(int id);
}