using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;

namespace Equipments.Application.Services;

public class TypeEquipmentService(ITypeEquipmentRepository typeEquipmentRepository) : ITypeEquipmentService
{
    public async Task AddAsync(TypeEquipment typeEquipment)
    {
        typeEquipment.Name = typeEquipment.Name.Trim();

        await typeEquipmentRepository.AddAsync(typeEquipment);
    }

    public async Task<List<TypeEquipment>> GetAllAsync()
    {
        var typesEquipments = await typeEquipmentRepository.GetAllAsync();

        return typesEquipments;
    }

    public async Task<TypeEquipment> GetByIdAsync(int typeEquipmentId)
    {
        var typeEquipment = await typeEquipmentRepository.GetByIdAsync(typeEquipmentId) ??
                                throw new NotFoundException(nameof(TypeEquipment), typeEquipmentId);


        return typeEquipment;
    }

    public async Task UpdateAsync(TypeEquipment typeEquipment)
    {
        typeEquipment.Name = typeEquipment.Name.Trim();

        await typeEquipmentRepository.UpdateAsync(typeEquipment);
    }
}