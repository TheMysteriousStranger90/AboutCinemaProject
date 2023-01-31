using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AboutCinemaProjectContext _context;
    private readonly DbSet<T> _set;

    public GenericRepository(AboutCinemaProjectContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }
        
    public async Task<T> GetByIdAsync(int id)
    {
        return await _set.FindAsync(id).AsTask();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _set.AsNoTracking().ToListAsync();
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }
        
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_set.AsQueryable(), spec);
    }

    public void Add(T entity)
    {
        _set.Add(entity);
    }

    public void Update(T entity)
    {
        _set.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity)
    {
        _set.Remove(entity);
    }
}