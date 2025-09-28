using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Services.TypesEquipments.Dto.Create;
using Equipments.Domain;

namespace Equipments.Application.Services.TypesEquipments;

public class TypeEquipmentService(ITypeEquipmentRepository typeEquipmentRepository) : ITypeEquipmentService
{
    public async Task AddAsync(TypeEquipmentDtoInput typeEquipmentDtoInput)
    {
        var typeEquipment = new TypeEquipment
        {
            Name = typeEquipmentDtoInput.Name.Trim(),
        };

        await typeEquipmentRepository.AddAsync(typeEquipment);
    }
}