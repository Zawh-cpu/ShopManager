using ShopManager.Infrastructure.Data;
using ShopManager.Infrastructure.Data.Entities;
using ShopManager.Infrastructure.Interfaces;

namespace ShopManager.Infrastructure.Services;

public class BaseRepository : IBaseRepository
{
    private readonly ApplicationDbContext _context;
    
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
    }
}