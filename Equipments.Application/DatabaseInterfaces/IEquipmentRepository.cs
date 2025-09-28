using Equipments.Application.Services.Equipments.Dto.Create;
using Equipments.Application.Services.Equipments.Dto.Edit;
using Equipments.Application.Services.Equipments.Dto.Paged;
using Equipments.Domain;

namespace Equipments.Application.DatabaseInterfaces;

public interface IEquipmentRepository
{
    Task<(List<EquipmentsPagedDtoOutput> Equipments, int CountEquipmentsWithFilter)> GetPagedAsync(int countSkip, int countTake, EquipmentsFilterDtoInput equipmentsFilterDtoInput);
    
    Task<List<EployeeForCreateEquipmentDtoOuput>> GetEmployeesForCreateEquipmentAsync();
    Task<List<TypeEquipmentForCreateEquipmentDtoOutput>> GetTypesEquipmentsForCreateEquipmentAsync();
    
    Task<List<EployeeForEditEquipmentDtoOuput>> GetEmployeesForEditEquipmentAsync();
    Task<List<FacilitiyForEditEquipmenDtoOuput>> GetFacilitiesForEditEquipmentAsync();
    Task<List<TypeEquipmentForEditEquipmenDtoOutput>> GetTypesEquipmentsForEditEquipmentAsync();

    Task AddAsync(EquipmentCreateDtoInput equipmentCreateDtoInput);
    Task RemoveAsync(Equipment equipment);
    Task<Equipment?> GetByIdAsync(int id);
    Task UpdateAsync(Equipment equipment);
}