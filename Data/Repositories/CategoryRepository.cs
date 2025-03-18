using Core.Entites;
using Core.Interfaces;
using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CategoryRepository(ApplicationDbContext context) : ICatogoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();

    }

    public async Task<Category> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category entity)
    {
        await _context.Categories.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category entity)
    {
        _context.Categories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Categories.FindAsync(id);
        if (entity != null)
        {
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}

