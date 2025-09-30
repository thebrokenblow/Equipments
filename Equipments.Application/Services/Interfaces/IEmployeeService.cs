using Equipments.Application.Common;
using Equipments.Domain.Entities;
using Equipments.Domain.QueryModels.Employees;

namespace Equipments.Application.Services.Interfaces;

public interface IEmployeeService
{
    Task AddAsync(Employee employee);
    Task RemoveByIdAsync(int id);
    Task<List<EmployeeModel>> GetForSelectAsync();
    Task<PagedResult<EmployeeModel>> GetPagedAsync(int pageNumber, int pageSize);
}