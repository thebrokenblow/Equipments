using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

/// <summary>
/// Реализация репозитория для работы с данными пользователей
/// </summary>
public class UserRepository(EquipmentsDbContext context) : IUserRepository
{
    /// <summary>
    /// Получает пользователя по паролю
    /// </summary>
    /// <param name="password">Пароль пользователя</param>
    /// <returns>Задача, результатом которой является сущность пользователя или null если не найден</returns>
    public async Task<User?> GetByPasswordAsync(string password)
    {
        var users = await context.Users.FirstOrDefaultAsync(user => user.Password == password);
        return users;
    }
}