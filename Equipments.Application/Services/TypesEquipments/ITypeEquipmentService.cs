using Equipments.Application.Services.TypesEquipments.Dto.Create;

namespace Equipments.Application.Services.TypesEquipments;

public interface ITypeEquipmentService
{
    Task AddAsync(TypeEquipmentDtoInput typeEquipmentDtoInput);
}
