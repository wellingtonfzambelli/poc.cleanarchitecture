using CleanArchitecture.Domain.Shared;

namespace CleanArchitecture.Domain.Entities.UserAggregate;

public sealed class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
}