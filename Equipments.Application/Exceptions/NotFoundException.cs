namespace Equipments.Application.Exceptions;

/// <summary>
/// Исключение, которое возникает при попытке доступа к сущности, которая не была найдена.
/// </summary>
/// <param name="name">Название типа сущности.</param>
/// <param name="key">Идентификатор сущности, которая не была найдена.</param>
public class NotFoundException(string name, object key) : Exception($"Entity \"{name}\" ({key}) not found.")
{
}