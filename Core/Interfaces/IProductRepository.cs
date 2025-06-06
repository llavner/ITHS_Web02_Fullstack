﻿using Core.Entites;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task AddAsync(Product entity);
    Task UpdateAsync(Product entity);
    Task DeleteAsync(int id);
}

