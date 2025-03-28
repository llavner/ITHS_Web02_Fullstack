using Core.Entites;
using Core.Interfaces;
using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();

    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity != null)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}

