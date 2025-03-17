using ShopManager.Core.Entities;

namespace ShopManager.Core.Interfaces;

public interface IBaseRepository
{
    Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class;
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task SaveAsync();

    Task<User?> GetUserByLoginOrEmail(string login);

    Task<User?> GetUserByIdAsync(Guid userId);
}