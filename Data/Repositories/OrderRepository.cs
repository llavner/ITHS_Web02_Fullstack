using Core.Entites;
using Core.Interfaces;
using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();

    }

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task AddAsync(Order entity)
    {
        await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        _context.Orders.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Orders.FindAsync(id);
        if (entity != null)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

}

