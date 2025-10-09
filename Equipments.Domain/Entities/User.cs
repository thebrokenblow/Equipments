namespace Equipments.Domain.Entities;

/// <summary>
/// Сущность пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public required string Password { get; set; }
}