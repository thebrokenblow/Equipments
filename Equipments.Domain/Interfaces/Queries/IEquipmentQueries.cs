using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Domain.Interfaces.Queries;

public interface IEquipmentQueries
{
    Task<(List<EquipmentListModel> Equipments, int CountEquipmentsWithFilter)> GetFilteredRangeAsync(
        int countSkip, 
        int countTake, 
        EquipmentFilterModel equipmentFilterModel);
}