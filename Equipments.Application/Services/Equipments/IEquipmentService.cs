using Equipments.Application.Services.Equipments.Dto.Create;
using Equipments.Application.Services.Equipments.Dto.Edit;
using Equipments.Application.Services.Equipments.Dto.Paged;
using Equipments.Application.Services.Equipments.Vm;

namespace Equipments.Application.Services.Equipments;

public interface IEquipmentService
{
    Task AddAsync(EquipmentCreateDtoInput equipment);
    Task EditAsync(EquipmentEditDtoInput equipmentEditViewModel);
    Task RemoveByIdAsync(int equipmentId);
    Task<EquipmentEditVm> GetEquipmentForEditAsync(int equipmentId);
    Task<EquipmentPagedVm> GetPagedEquipmentsAsync(EquipmentsPagedDtoInput equipmentsPagedDtoInput);
}