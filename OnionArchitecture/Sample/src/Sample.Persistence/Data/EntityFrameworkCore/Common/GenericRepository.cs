using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Interfaces.Repositories;
using Sample.Domain.Common;
using Sample.Persistence.Data.EntityFrameworkCore.Context;

namespace Sample.Persistence.Data.EntityFrameworkCore.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext context;

    public GenericRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}
