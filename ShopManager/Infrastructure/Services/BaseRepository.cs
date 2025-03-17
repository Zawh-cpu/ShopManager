using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShopManager.Core.Entities;
using ShopManager.Core.Interfaces;
using ShopManager.Infrastructure.Data;

namespace ShopManager.Infrastructure.Services;

public class BaseRepository : IBaseRepository
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction? _transaction;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }
    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
            _transaction = null;
        }
    }
    
    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            _transaction = null;
        }
    }
    
    public async Task SaveAsync()
    {
        if (_transaction == null)
        {
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<User?> GetUserByLoginOrEmail(string login)
    {
        return await _context.Users.Where(user => user.Login == login || user.Email == login).FirstOrDefaultAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _context.Users.Where(user => user.Id == userId).FirstOrDefaultAsync();
    }
}