using System.Linq.Expressions;

namespace ProjetoEscola.Domain.Interface.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Select(params string[] includes);
        IQueryable<T> Select(Expression<Func<T, bool>> expression, params string[] includes);
        T Insert(T entity);
        void Insert(IEnumerable<T> entity);
        void Update(T entity);
        T Update(T entity, params string[] fieldsToUpdate);
        T Update(T entity, bool cascade = false);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();
        void Dispose();
    }
}
