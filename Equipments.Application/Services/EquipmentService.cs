using Equipments.Application.Common;
using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Domain.QueryModels.Equipments;

namespace Equipments.Application.Services;

public class EquipmentService(
    IEquipmentRepository equipmentRepository, 
    IEquipmentQueries equipmentQueries) : IEquipmentService
{
    public async Task AddAsync(Equipment equipment)
    {
        equipment.SerialNumber = equipment.SerialNumber.Trim();
        equipment.CabinetNumber = equipment.CabinetNumber.Trim();
        equipment.ConclusionSpecResearch = equipment.ConclusionSpecResearch?.Trim();
        equipment.ConclusionSpecialProject = equipment.ConclusionSpecialProject?.Trim();
        equipment.Note = equipment.Note?.Trim();

        await equipmentRepository.AddAsync(equipment);
    }

    public async Task RemoveByIdAsync(int id)
    {
        var equipment = await equipmentRepository.GetByIdAsync(id) ?? 
                                throw new NotFoundException(nameof(Equipment), id);

        await equipmentRepository.RemoveAsync(equipment);
    }

    public async Task UpdateAsync(Equipment equipment)
    {
        equipment.SerialNumber = equipment.SerialNumber.Trim();
        equipment.CabinetNumber = equipment.CabinetNumber.Trim();
        equipment.ConclusionSpecResearch = equipment.ConclusionSpecResearch?.Trim();
        equipment.ConclusionSpecialProject = equipment.ConclusionSpecialProject?.Trim();
        equipment.Note = equipment.Note?.Trim();

        await equipmentRepository.UpdateAsync(equipment);
    }

    public async Task<PagedResult<EquipmentDetailsListModel>> GetFilteredPagedAsync(
        int pageNumber,
        int pageSize,
        EquipmentFilterModel equipmentFilterModel)
    {
        equipmentFilterModel.SerialNumber = equipmentFilterModel.SerialNumber?.Trim();
        equipmentFilterModel.CabinetNumber = equipmentFilterModel.CabinetNumber?.Trim();

        int countSkip = (pageNumber - 1) * pageSize;
        var equipmentsFilteredPage = await equipmentQueries.GetFilteredRangeAsync(countSkip, pageSize, equipmentFilterModel);

        var pagedEquipments = new PagedResult<EquipmentDetailsListModel>(
            equipmentsFilteredPage.Equipments, 
            equipmentsFilteredPage.CountEquipmentsWithFilter, 
            pageNumber, 
            pageSize);

        return pagedEquipments;
    }

    public async Task<Equipment> GetByIdAsync(int id)
    {
        var equipment = await equipmentRepository.GetByIdAsync(id) ?? 
                                throw new NotFoundException(nameof(Equipment), id);

        return equipment;
    }

    public async Task<EquipmentDetailsModel> GetDetailsByIdAsync(int id)
    {
        var equipment = await equipmentQueries.GetDetailsByIdAsync(id) ??
                                throw new NotFoundException(nameof(Equipment), id);

        return equipment;
    }

    public async Task DuplicateAsync(int equipmentId)
    {
        var equipment = await equipmentRepository.GetByIdAsync(equipmentId) ??
                                throw new NotFoundException(nameof(Equipment), equipmentId);

        var duplicateEquipment = new Equipment
        {
            SerialNumber = equipment.SerialNumber,
            CabinetNumber = equipment.CabinetNumber,
            TypeEquipmentId = equipment.TypeEquipmentId,
            EmployeeId = equipment.EmployeeId,
            ConclusionSpecialProject = equipment.ConclusionSpecialProject,
            ConclusionSpecResearch = equipment.ConclusionSpecResearch,
            Note = equipment.Note,
            FacilityId = equipment.FacilityId,
        };

        await equipmentRepository.AddAsync(duplicateEquipment);
    }
}