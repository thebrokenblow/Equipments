using Equipments.Domain.Entities;
using Equipments.Domain.Interfaces.Repositories;
using Equipments.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Persistence.Repositories;

public class UserRepository(EquipmentsDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(int id)
    {
        var user =  await context.Users.FindAsync(id);

        return user;
    }

    public async Task<User?> GetByPasswordAsync(string password)
    {
        var users = await context.Users.FirstOrDefaultAsync(user => user.Password == password);

        return users;
    }

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await context.Users.ToListAsync();

        return users;
    }
}