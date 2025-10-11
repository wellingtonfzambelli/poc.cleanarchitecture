using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Cache;

public interface ICacheService
{
    Task InsertAsync<T>(T type) where T : class;
    Task<T?> GetByIdAsync<T>(string id) where T : class;
    Task<T?> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
    Task DeleteAsync<T>(T id) where T : class;
}