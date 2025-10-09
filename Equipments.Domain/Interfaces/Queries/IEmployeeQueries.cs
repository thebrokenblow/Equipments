using Equipments.Domain.QueryModels.Employees;

namespace Equipments.Domain.Interfaces.Queries;

/// <summary>
/// Предоставляет методы для выполнения запросов к данным сотрудников.
/// </summary>
public interface IEmployeeQueries
{
    /// <summary>
    /// Получает диапазон сотрудников с общим количеством.
    /// </summary>
    /// <param name="countSkip">Количество пропускаемых записей.</param>
    /// <param name="countTake">Количество получаемых записей.</param>
    /// <returns>Задача, результатом которой является кортеж содержащий список сотрудников и общее количество.</returns>
    Task<(List<EmployeeModel> Employees, int CountAllEmployees)> GetRangeAsync(int countSkip, int countTake);

    /// <summary>
    /// Получает список сотрудников для выбора в выпадающих списках.
    /// </summary>
    /// <returns>Задача, результатом которой является список моделей сотрудников для выбора.</returns>
    Task<List<EmployeeModel>> GetForSelectAsync();
}