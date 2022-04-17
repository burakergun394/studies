using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore.Repositories
{
    public class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfCoreRepository(TContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _context == null
                ? throw new ArgumentNullException("Context Is Null")
                : _context.Set<TEntity>().AsNoTracking().SingleOrDefault(predicate);

        }

        public List<TEntity> GetList(Func<TEntity, bool> predicate = null)
        {
            return predicate == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
