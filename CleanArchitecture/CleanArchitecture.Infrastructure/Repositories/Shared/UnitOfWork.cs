using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitecture.Infrastructure.Repositories.Shared;

public sealed class UnitOfWork : IUnitOfWork
{
    public IUserRepository UserRepository { get; }

    private readonly CleanArchitectureDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork
    (
        CleanArchitectureDbContext context,
        IUserRepository userRepository
    )
    {
        UserRepository = userRepository;
        _context = context;
    }

    public async Task OpenTransactionAsync(CancellationToken ct) =>
        _transaction = await _context.Database.BeginTransactionAsync(ct);

    public async Task CommitTransaction(CancellationToken cancellationToken) =>
        await _transaction.CommitAsync(cancellationToken);

    public async Task RollBackTransaction(CancellationToken cancellationToken) =>
        await _transaction.RollbackAsync(cancellationToken);

    public async Task SaveAsync(CancellationToken ct) =>
        await _context.SaveChangesAsync(ct);

    public async Task DisposeAsync() =>
        await _context.DisposeAsync();
}