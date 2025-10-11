using Redis.OM.Modeling;

namespace CleanArchitecture.Infrastructure.Cache.Model;

[Document(StorageType = StorageType.Json)]
public sealed record CreateUserCache
{
    [RedisIdField][Indexed] public Guid Id { get; init; }
    [Indexed] public string Name { get; init; }
    [Indexed] public string Email { get; init; }
    [Indexed] public DateTime CreatedAt { get; init; }
}