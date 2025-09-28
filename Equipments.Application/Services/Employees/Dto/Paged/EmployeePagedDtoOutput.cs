namespace Equipments.Application.Services.Employees.Dto.Paged;

public class EmployeePagedDtoOutput
{
    public required int Id { get; init; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
}