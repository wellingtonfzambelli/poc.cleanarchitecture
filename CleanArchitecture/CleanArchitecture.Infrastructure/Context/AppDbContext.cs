using CleanArchitecture.Domain.Entities.UserAggregate;
using CleanArchitecture.Infrastructure.Repositories.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserBuilder());

        base.OnModelCreating(modelBuilder);
    }
}