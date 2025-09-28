using Equipments.Application.Services.Equipments.Dto.Create;
using Equipments.Application.Services.Equipments.Dto.Paged;

namespace Equipments.Application.Services.Equipments.Vm;

public class EquipmentPagedVm
{
    public required int CountEquipmentsWithFilter { get; init; }
    public required List<EquipmentsPagedDtoOutput> Equipments { get; init; }
    public required List<EployeeForCreateEquipmentDtoOuput> EmployeesForCreateEquipment { get; init; }
    public required List<TypeEquipmentForCreateEquipmentDtoOutput> TypesEquipmentForCreateEquipmen { get; init; }
}