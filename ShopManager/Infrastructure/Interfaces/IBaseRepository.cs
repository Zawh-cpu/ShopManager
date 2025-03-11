using ShopManager.Infrastructure.Data.Entities;

namespace ShopManager.Infrastructure.Interfaces;

public interface IBaseRepository
{
    Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class;
}