using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories.UserAggregate;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(CleanArchitectureDbContext context) : base(context)
    { }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken) =>
        await base.Context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
}