namespace Equipments.Domain.QueryModels.Employees;

public class EmployeeModel
{
    /// <summary>
    /// Уникальный идентификатор сотрудника
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Фамилия и инициалы
    /// </summary>
    public required string SurnameAndInitials { get; set; }

    /// <summary>
    /// Наименование подразделения 
    /// </summary>
    public required string? SubdivisionName { get; set; }

    /// <summary>
    /// Примечание
    /// </summary>
    public string? Note { get; set; }
}