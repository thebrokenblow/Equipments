using Equipments.Application.Services.Equipments.Dto.Edit;
using Equipments.Domain;

namespace Equipments.Application.Services.Equipments.Vm;

public class EquipmentEditVm
{
    public required Equipment Equipment { get; init; }
    public required List<EployeeForEditEquipmentDtoOuput> EmployeesForEditEquipment { get; init; }
    public required List<TypeEquipmentForEditEquipmenDtoOutput> TypesEquipmentsForEditEquipmen { get; init; }
    public required List<FacilitiyForEditEquipmenDtoOuput> FacilitiesForEditEquipmen { get; init; }
}