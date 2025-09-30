using Equipments.Domain.QueryModels.Employees;

namespace Equipments.Domain.Interfaces.Queries;

public interface IEmployeeQueries
{
    Task<(List<EmployeeModel> Employees, int CountAllEmployees)> GetRangeAsync(int countSkip, int countTake);
    Task<List<EmployeeModel>> GetForSelectAsync();
}