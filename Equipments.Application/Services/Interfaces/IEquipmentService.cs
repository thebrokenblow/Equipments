using Equipments.Application.Common;
using Equipments.Domain.Entities;
using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Application.Services.Interfaces;

public interface IEquipmentService
{
    Task AddAsync(Equipment equipment);
    Task RemoveByIdAsync(int id);
    Task UpdateAsync(Equipment equipment);
    Task<Equipment> GetByIdAsync(int id);
    Task<PagedResult<EquipmentListModel>> GetFilteredPagedAsync(
        int pageNumber,
        int pageSize,
        EquipmentFilterModel equipmentFilterModel);
}