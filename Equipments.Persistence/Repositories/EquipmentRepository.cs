using Equipments.Application.DatabaseInterfaces;
using Equipments.Application.Services.Equipments.Dto.Create;
using Equipments.Application.Services.Equipments.Dto.Edit;
using Equipments.Application.Services.Equipments.Dto.Paged;
using Equipments.Domain;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class EquipmentRepository(EquipmentsDbContext context) : IEquipmentRepository
{
    public async Task<(List<EquipmentsPagedDtoOutput> Equipments, int CountEquipmentsWithFilter)> GetPagedAsync(int countSkip, int countTake, EquipmentsFilterDtoInput equipmentsFilterDtoInput)
    {
        var query = context.Equipments
                           .Include(equipment => equipment.Employee)
                           .Include(equipment => equipment.TypeEquipment)
                           .Where(equipment => equipment.FacilityId == equipmentsFilterDtoInput.FacilityId)
                           .AsQueryable();

        if (!string.IsNullOrEmpty(equipmentsFilterDtoInput.CabinetNumber))
        {
            query = query.Where(equipment => equipment.CabinetNumber.Contains(equipmentsFilterDtoInput.CabinetNumber));
        }

        if (!string.IsNullOrEmpty(equipmentsFilterDtoInput.SerialNumber))
        {
            query = query.Where(equipment => equipment.SerialNumber.Contains(equipmentsFilterDtoInput.SerialNumber));
        }

        var count = await query.CountAsync();

        var equipments = await query
                                .Skip(countSkip)
                                .Take(countTake)
                                .Select(equipment => new EquipmentsPagedDtoOutput
                                {
                                    Id = equipment.Id,
                                    CabinetNumber = equipment.CabinetNumber,
                                    SerialNumber = equipment.SerialNumber,
                                    TypeEquipment = equipment.TypeEquipment == null ? string.Empty : equipment.TypeEquipment.Name,
                                    FirstName = equipment.Employee == null ? string.Empty : equipment.Employee.FirstName,
                                    LastName = equipment.Employee == null ? string.Empty : equipment.Employee.LastName,
                                    MiddleName = equipment.Employee == null ? string.Empty : equipment.Employee.MiddleName,
                                    ConclusionSpecialProject = equipment.ConclusionSpecialProject,
                                    ConclusionSpecResearch = equipment.ConclusionSpecResearch,
                                    Note = equipment.Note,
                                })
                                .AsNoTracking()
                                .ToListAsync();

        return (equipments, count);
    }

    public async Task<List<EployeeForCreateEquipmentDtoOuput>> GetEmployeesForCreateEquipmentAsync()
    {
        var employees = await context.Employees.Select(
                                                    employee => new EployeeForCreateEquipmentDtoOuput
                                                    {
                                                        Id = employee.Id,
                                                        FirstName = employee.FirstName, 
                                                        LastName =  employee.LastName, 
                                                        MiddleName = employee.MiddleName 
                                                    }).ToListAsync();

        return employees;
    }

    public async Task<List<TypeEquipmentForCreateEquipmentDtoOutput>> GetTypesEquipmentsForCreateEquipmentAsync()
    {
        var typeEquipments = await context.TypeEquipments.Select(
            typeEquipment => new TypeEquipmentForCreateEquipmentDtoOutput
            {
                Id = typeEquipment.Id,
                Name = typeEquipment.Name
            })
            .ToListAsync();

        return typeEquipments;
    }

    public async Task<List<EployeeForEditEquipmentDtoOuput>> GetEmployeesForEditEquipmentAsync()
    {
        var employees = await context.Employees.Select(
                                                    employee => new EployeeForEditEquipmentDtoOuput
                                                    {
                                                        Id = employee.Id,
                                                        FirstName = employee.FirstName,
                                                        LastName = employee.LastName,
                                                        MiddleName = employee.MiddleName
                                                    }).ToListAsync();

        return employees;
    }

    public async Task<List<TypeEquipmentForEditEquipmenDtoOutput>> GetTypesEquipmentsForEditEquipmentAsync()
    {
        var typeEquipments = await context.TypeEquipments.Select(
            typeEquipment => new TypeEquipmentForEditEquipmenDtoOutput
            {
                Id = typeEquipment.Id,
                Name = typeEquipment.Name
            })
            .ToListAsync();

        return typeEquipments;
    }

    public async Task<List<FacilitiyForEditEquipmenDtoOuput>> GetFacilitiesForEditEquipmentAsync()
    {
        var facilities = await context.Facilities.Select(
                                                facility => new FacilitiyForEditEquipmenDtoOuput
                                                {
                                                    Id = facility.Id,
                                                    Name = facility.Name
                                                })
                                                .ToListAsync();

        return facilities;
    }

    public async Task AddAsync(EquipmentCreateDtoInput equipmentCreateDtoInput)
    {
        var equipment = new Equipment
        {
            SerialNumber = equipmentCreateDtoInput.SerialNumber,
            CabinetNumber = equipmentCreateDtoInput.CabinetNumber,
            TypeEquipmentId = equipmentCreateDtoInput.TypeEquipmentId,
            EmployeeId = equipmentCreateDtoInput.EmployeeId,
            ConclusionSpecialProject = equipmentCreateDtoInput.ConclusionSpecialProject,
            ConclusionSpecResearch = equipmentCreateDtoInput.ConclusionSpecResearch,
            Note = equipmentCreateDtoInput.Note,
            FacilityId = equipmentCreateDtoInput.FacilityId,
        };

        await context.AddAsync(equipment);
        await context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Equipment equipment)
    {
        context.Remove(equipment);
        await context.SaveChangesAsync();
    }

    public async Task<Equipment?> GetByIdAsync(int id)
    {
        var equipment = await context.Equipments.FirstOrDefaultAsync(
                                                        equipment => equipment.Id == id);

        return equipment;
    }

    public async Task UpdateAsync(Equipment equipment)
    {
        context.Update(equipment);
        await context.SaveChangesAsync();
    }
}