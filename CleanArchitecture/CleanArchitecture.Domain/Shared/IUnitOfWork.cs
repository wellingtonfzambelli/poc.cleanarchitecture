namespace CleanArchitecture.Domain.Shared;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}