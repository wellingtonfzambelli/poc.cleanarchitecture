using Redis.OM;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Cache;

internal sealed class CacheService : ICacheService
{
    private readonly RedisConnectionProvider _provider;

    public CacheService(RedisConnectionProvider provider) =>
        _provider = provider;

    public async Task InsertAsync<T>(T type) where T : class
    {
        var collection = _provider.RedisCollection<T>();
        await collection.InsertAsync(type);
    }

    // requires [RedisIdField])
    public async Task<T?> GetByIdAsync<T>(string id) where T : class
    {
        var collection = _provider.RedisCollection<T>();
        return await collection.FindByIdAsync(id);
    }

    public async Task<T?> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class
    {
        var collection = _provider.RedisCollection<T>();
        return await collection.FirstOrDefaultAsync(predicate);
    }

    // requires [RedisIdField])
    public async Task DeleteAsync<T>(T id) where T : class
    {
        var collection = _provider.RedisCollection<T>();
        await collection.DeleteAsync(id);
    }
}