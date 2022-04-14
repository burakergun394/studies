using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository<T> where T: class, IEntity
    {
        public T Insert(T entity);
        public T Update(T entity);
        public void Delete(T entity);
        public T Get(Func<T, bool> predicate);
        public List<T> GetList(Func<T, bool> predicate);

    }
}
