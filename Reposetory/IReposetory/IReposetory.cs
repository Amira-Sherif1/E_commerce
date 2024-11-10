using System.Linq.Expressions;

namespace E_Commerce.Reposetory.IReposetory
{
    public interface IReposetory<T>where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, object>>? includeprop = null ,Expression<Func<T,bool>>? expression=null , bool tracking = false);
        T? GetOne(Expression<Func<T, bool>> expresion);
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();
    }
}
