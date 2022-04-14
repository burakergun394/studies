using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore.Repositories
{
    public class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        TContext _context;

        public EfCoreRepository(TContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        //public void Delete(TEntity entity)
        //{
        //    //var deletedEntity = _context.Entry(entity);
        //    //deletedEntity.State = EntityState.Deleted;
        //    //_context.SaveChanges();
        //}

        //public TEntity Get(Func<TEntity, bool> predicate)
        //{
        //    //using var context = new TContext();
        //    //return context.Set<TEntity>().SingleOrDefault(predicate);

        //}

        //public List<TEntity> GetList(Func<TEntity, bool> predicate)
        //{
        //    using var context = new TContext();
        //    return predicate == null
        //        ? context.Set<TEntity>().ToList()
        //        : context.Set<TEntity>().Where(predicate).ToList();
        //}

        //public TEntity Insert(TEntity entity)
        //{
        //    using var context = new TContext();
        //    var addedEntity = context.Entry(entity);
        //    addedEntity.State = EntityState.Added;
        //    context.SaveChanges();
        //    return entity;
        //}

        //public TEntity Update(TEntity entity)
        //{
        //    using var context = new TContext();
        //    var updatedEntity = context.Entry(entity);
        //    updatedEntity.State = EntityState.Modified;
        //    context.SaveChanges();
        //    return entity;
        //}
    }
}
