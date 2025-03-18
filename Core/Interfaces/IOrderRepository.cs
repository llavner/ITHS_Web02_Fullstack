using Core.Entites;

namespace Core.Interfaces;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task AddAsync(Order entity);
    Task UpdateAsync(Order entity);
    Task DeleteAsync(int id);
}

