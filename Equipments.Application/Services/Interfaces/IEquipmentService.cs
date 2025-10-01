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
    Task<EquipmentDetailsModel> GetDetailsByIdAsync(int id);
    Task<PagedResult<EquipmentDetailsListModel>> GetFilteredPagedAsync(
        int pageNumber,
        int pageSize,
        EquipmentFilterModel equipmentFilterModel);
    Task DuplicateAsync(int equipmentId);
}