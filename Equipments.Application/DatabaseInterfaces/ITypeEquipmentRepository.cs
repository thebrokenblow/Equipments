using Equipments.Domain;

namespace Equipments.Application.DatabaseInterfaces;

public interface ITypeEquipmentRepository
{
    Task AddAsync(TypeEquipment typeEquipment);
}