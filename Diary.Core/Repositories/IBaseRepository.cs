using Diary.Core.Entities;

namespace Diary.Core.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    IAsyncEnumerable<T> GetAllAsync();
    Task<T> CreateAsync(T entity);
}
