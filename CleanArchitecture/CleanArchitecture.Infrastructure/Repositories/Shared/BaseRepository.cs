using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories.Shared;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context) =>
        Context = context;

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await Context.Set<T>().FindAsync(new object?[] { id }, cancellationToken);


    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken) =>
        await Context.Set<T>().ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        await Context.Set<T>().AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}