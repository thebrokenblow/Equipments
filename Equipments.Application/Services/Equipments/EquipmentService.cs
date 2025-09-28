using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Exceptions;
using Equipments.Application.Services.Equipments.Dto.Create;
using Equipments.Application.Services.Equipments.Dto.Edit;
using Equipments.Application.Services.Equipments.Dto.Paged;
using Equipments.Application.Services.Equipments.Vm;
using Equipments.Domain;

namespace Equipments.Application.Services.Equipments;

public class EquipmentService(IEquipmentRepository equipmentRepository) : IEquipmentService
{
    public async Task<EquipmentPagedVm> GetPagedEquipmentsAsync(EquipmentsPagedDtoInput equipmentsPagedDtoInput)
    {
        int countSkip = (equipmentsPagedDtoInput.PageNumber - 1) * equipmentsPagedDtoInput.PageSize;
        int countTake = equipmentsPagedDtoInput.PageSize;

        var equipmentsFilterDtoInput = new EquipmentsFilterDtoInput
        {
            FacilityId = equipmentsPagedDtoInput.FacilityId,
            CabinetNumber = equipmentsPagedDtoInput.CabinetNumber?.Trim(),
            SerialNumber = equipmentsPagedDtoInput?.SerialNumber?.Trim(),
        };

        var pagedEquipments = await equipmentRepository.GetPagedAsync(countSkip, countTake, equipmentsFilterDtoInput);
        var employees = await equipmentRepository.GetEmployeesForCreateEquipmentAsync();
        var typesEquipment = await equipmentRepository.GetTypesEquipmentsForCreateEquipmentAsync();

        var equipmentPagedVM = new EquipmentPagedVm
        {
            CountEquipmentsWithFilter = pagedEquipments.CountEquipmentsWithFilter,
            Equipments = pagedEquipments.Equipments,
            EmployeesForCreateEquipment = employees,
            TypesEquipmentForCreateEquipmen = typesEquipment,
        };

        return equipmentPagedVM;
    }

    public async Task AddAsync(EquipmentCreateDtoInput equipmentCreateDtoInput)
    {
        equipmentCreateDtoInput.SerialNumber = equipmentCreateDtoInput.SerialNumber.Trim();
        equipmentCreateDtoInput.CabinetNumber = equipmentCreateDtoInput.CabinetNumber.Trim();

        if (equipmentCreateDtoInput.ConclusionSpecialProject is not null)
        {
            equipmentCreateDtoInput.ConclusionSpecialProject = equipmentCreateDtoInput.ConclusionSpecialProject.Trim();
        }

        if (equipmentCreateDtoInput.ConclusionSpecResearch is not null)
        {
            equipmentCreateDtoInput.ConclusionSpecResearch = equipmentCreateDtoInput.ConclusionSpecResearch.Trim();
        }

        if (equipmentCreateDtoInput.Note is not null)
        {
            equipmentCreateDtoInput.Note = equipmentCreateDtoInput.Note.Trim();
        }

        await equipmentRepository.AddAsync(equipmentCreateDtoInput);
    }

    public async Task RemoveByIdAsync(int id)
    {
        var equipment = await equipmentRepository.GetByIdAsync(id) ?? 
                                throw new NotFoundException(nameof(Equipment), id);

        await equipmentRepository.RemoveAsync(equipment);
    }

    public async Task EditAsync(EquipmentEditDtoInput equipmentEditViewModel)
    {                           
        var equipment = await equipmentRepository.GetByIdAsync(equipmentEditViewModel.EquipmentId) ?? 
                                throw new NotFoundException(nameof(Equipment), equipmentEditViewModel.EquipmentId);

        equipment.SerialNumber = equipmentEditViewModel.SerialNumber.Trim();
        equipment.CabinetNumber = equipmentEditViewModel.CabinetNumber.Trim();
        equipment.TypeEquipmentId = equipmentEditViewModel.TypeEquipmentId;
        equipment.EmployeeId = equipmentEditViewModel.EmployeeId;

        if (equipmentEditViewModel.ConclusionSpecialProject is not null)
        {
            equipment.ConclusionSpecialProject = equipmentEditViewModel.ConclusionSpecialProject.Trim();
        }

        if (equipmentEditViewModel.ConclusionSpecResearch is not null)
        {
            equipment.ConclusionSpecResearch = equipmentEditViewModel.ConclusionSpecResearch.Trim();
        }

        if (equipmentEditViewModel.Note is not null)
        {
            equipment.Note = equipmentEditViewModel.Note.Trim();
        }

        equipment.FacilityId = equipmentEditViewModel.FacilityId;

        await equipmentRepository.UpdateAsync(equipment);
    }

    public async Task<EquipmentEditVm> GetEquipmentForEditAsync(int id)
    {
        var equipment = await equipmentRepository.GetByIdAsync(id) ?? 
                                throw new NotFoundException(nameof(Equipment), id);

        var employees = await equipmentRepository.GetEmployeesForEditEquipmentAsync();
        var facilities = await equipmentRepository.GetFacilitiesForEditEquipmentAsync();
        var typesEquipments = await equipmentRepository.GetTypesEquipmentsForEditEquipmentAsync();

        var equipmentEditVm = new EquipmentEditVm
        {
            Equipment = equipment,
            EmployeesForEditEquipment = employees,
            FacilitiesForEditEquipmen = facilities,
            TypesEquipmentsForEditEquipmen = typesEquipments
        };

        return equipmentEditVm;
    }
}