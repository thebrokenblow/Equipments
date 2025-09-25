using Equipments.View.ViewModels.Equipment;

namespace Equipments.View.Repositories.Interfaces;

public interface IEquipmentRepository
{
    Task<List<EquipmentViewModel>> GetRangeAsync(int numberPage, int pageSize);
}