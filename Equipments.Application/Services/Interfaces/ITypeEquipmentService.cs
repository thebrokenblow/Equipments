using Equipments.Domain.Entities;

namespace Equipments.Application.Services.Interfaces;

public interface ITypeEquipmentService
{
    Task AddAsync(TypeEquipment typeEquipment);
    Task<List<TypeEquipment>> GetAllAsync();
}