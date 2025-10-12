using Equipments.Application.Common;
using Equipments.Application.Exceptions;
using Equipments.Application.Services.Interfaces;
using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Queries;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Domain.QueryModels.Employees;

namespace Equipments.Application.Services;

/// <summary>
/// Реализация сервиса для работы с сотрудниками.
/// </summary>
/// <remarks>
/// Предоставляет бизнес-логику для управления сотрудниками, включая валидацию и обработку данных.
/// </remarks>
/// <param name="employeeRepository">Репозиторий для операций с данными сотрудников</param>
/// <param name="employeeQueries">Запросы для получения данных сотрудников</param>
public class EmployeeService(
    IEmployeeRepository employeeRepository,
    IEmployeeQueries employeeQueries) : IEmployeeService
{
    /// <summary>
    /// Добавляет нового сотрудника с предварительной обработкой данных.
    /// </summary>
    /// <remarks>
    /// Выполняет автоматическое обрезание пробелов в текстовых полях.
    /// </remarks>
    /// <param name="employee">Данные сотрудника для добавления</param>
    public async Task AddAsync(Employee employee)
    {
        employee.SurnameAndInitials = employee.SurnameAndInitials.Trim();
        employee.SubdivisionName = employee.SubdivisionName?.Trim();
        employee.Note = employee.Note?.Trim();

        await employeeRepository.AddAsync(employee);
    }

    /// <summary>
    /// Удаляет сотрудника по идентификатору после проверки существования.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника для удаления</param>
    /// <exception cref="NotFoundException">Выбрасывается, если сотрудник не найден</exception>
    public async Task RemoveByIdAsync(int id)
    {
        var employee = await employeeRepository.GetByIdAsync(id) ??
                            throw new NotFoundException(nameof(Employee), id);

        await employeeRepository.RemoveAsync(employee);
    }

    /// <summary>
    /// Получает список сотрудников для выбора в выпадающих списках.
    /// </summary>
    /// <returns>Список моделей сотрудников для выбора</returns>
    public async Task<List<EmployeeModel>> GetForSelectAsync()
    {
        var employees = await employeeQueries.GetForSelectAsync();
        return employees;
    }

    /// <summary>
    /// Получает постраничный список сотрудников.
    /// </summary>
    /// <remarks>
    /// Вычисляет смещение для пагинации на основе номера страницы и размера страницы.
    /// </remarks>
    /// <param name="pageNumber">Номер страницы (начинается с 1)</param>
    /// <param name="pageSize">Количество элементов на странице</param>
    /// <returns>Постраничный результат с сотрудниками</returns>
    public async Task<PagedResult<EmployeeModel>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var countSkip = (pageNumber - 1) * pageSize;
        var (employees, countEmployee) = await employeeQueries.GetRangeAsync(countSkip, pageSize);

        var pagedEmployee = new PagedResult<EmployeeModel>(employees, countEmployee, pageNumber, pageSize);
        return pagedEmployee;
    }

    /// <summary>
    /// Получает сотрудника по идентификатору с проверкой существования.
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <returns>Сущность сотрудника</returns>
    /// <exception cref="NotFoundException">Выбрасывается, если сотрудник не найден</exception>
    public async Task<Employee> GetByIdAsync(int id)
    {
        var employee = await employeeRepository.GetByIdAsync(id) ??
                                        throw new NotFoundException(nameof(Employee), id);

        return employee;
    }

    /// <summary>
    /// Обновляет данные сотрудника.
    /// </summary>
    /// <param name="employee">Обновленные данные сотрудника</param>
    public async Task UpdateAsync(Employee employee)
    {
        var isExist = await employeeRepository.IsExistAsync(employee.Id);

        if (!isExist)
        {
            throw new NotFoundException(nameof(Equipment), employee.Id);
        }

        employee.SurnameAndInitials = employee.SurnameAndInitials.Trim();
        employee.SubdivisionName = employee.SubdivisionName?.Trim();
        employee.Note = employee.Note?.Trim();

        await employeeRepository.UpdateAsync(employee);
    }
}