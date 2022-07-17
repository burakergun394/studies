using Sample.Domain.Common;

namespace Sample.Application.Common.Interfaces.Repositories;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task AddAsync(T entity);
}
