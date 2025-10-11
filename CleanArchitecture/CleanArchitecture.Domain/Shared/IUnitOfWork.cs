using CleanArchitecture.Domain.Entities.UserAggregate;

namespace CleanArchitecture.Domain.Shared;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken ct);
    Task OpenTransactionAsync(CancellationToken ct);
    Task CommitTransaction(CancellationToken cancellationToken);
    Task RollBackTransaction(CancellationToken cancellationToken);

    IUserRepository UserRepository { get; }
}