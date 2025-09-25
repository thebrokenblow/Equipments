using Equipments.View.Data;
using Equipments.View.Repositories.Interfaces;
using Equipments.View.ViewModels.Equipment;
using Microsoft.EntityFrameworkCore;

namespace Equipments.View.Repositories;

public class EquipmentRepository(EquipmentsDbContext context) : IEquipmentRepository
{
    public async Task<List<EquipmentViewModel>> GetRangeAsync(int pageNumber, int pageSize)
    {
        var equipments = await context.Equipments
                                      .Include(equipment => equipment.Employee)
                                      .Include(equipment => equipment.TypeEquipment)
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .Select(equipment => new EquipmentViewModel
                                      {
                                          Id = equipment.Id,
                                          CabinetNumber = equipment.CabinetNumber,
                                          TypeEquipment = equipment.TypeEquipment.Name,
                                          FirstName = equipment.Employee!.FirstName,
                                          LastName = equipment.Employee.LastName,
                                          MiddleName = equipment.Employee.MiddleName,
                                          ConclusionSpecialProject = equipment.ConclusionSpecialProject,
                                          ConclusionSpecResearch = equipment.ConclusionSpecResearch,
                                          Note = equipment.Note,
                                      })
                                      .AsNoTracking()
                                      .ToListAsync();
        return equipments;
    }
}