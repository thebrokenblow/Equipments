using Equipments.Domain.Entities;

namespace Equipments.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task RemoveAsync(Employee employee);
}