namespace Equipments.Application.Services.Employees.Dto.Create;

public class EmployeeCreateDtoInput
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
}