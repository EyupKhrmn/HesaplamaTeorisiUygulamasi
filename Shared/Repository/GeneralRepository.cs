using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Shared.Repository;

public class GeneralRepository<TContext> : IGeneralRepository where TContext : DbContext
{
    protected TContext _context { get; set; }

    public GeneralRepository(TContext context)
    {
        _context = context;
    }
    
    public void add(object entity)
    {
        _context.Add(entity);
    }

    public void delete(object entity)
    {
        _context.Remove(entity);
    }

    public void update(object entity)
    {
        _context.Update(entity);
    }
    
    public IQueryable<TEntity> Query<TEntity>()
        where TEntity : class
    {
        return _context.Set<TEntity>();
    }
}