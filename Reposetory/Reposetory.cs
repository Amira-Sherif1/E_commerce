using E_Commerce.Data;
using E_Commerce.Reposetory.IReposetory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Reposetory
{
    public class Reposetory<T> : IReposetory<T> where T : class
    {
        ApplicationDbContext dbcontext;
        DbSet<T> set;

        public Reposetory(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
             set = dbcontext.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>>? includeprop = null, Expression<Func<T, bool>>? expression = null, bool tracking = false)
        {
            
                IQueryable<T> query = set;

                // Apply no-tracking if requested
                if (!tracking)
                {
                    query = query.AsNoTracking();
                }

                // Apply filter if provided
                if (expression != null)
                {
                    query = query.Where(expression);
                }

                // Apply include if provided
                if (includeprop != null)
                {
                    query = query.Include(includeprop);
                }

                return query.ToList();
            


        }
        public T? GetOne(Expression<Func<T, bool>> expresion)
        {
            return set.Where(expresion).FirstOrDefault();

        }
        public void Add(T entity)
        {
            set.Add(entity);
        }
        public void Edit(T entity)
        {
            set.Update(entity);
        }
        public void Delete(T entity)
        {
            set.Remove(entity);
        }
        public void Save()
        {
            dbcontext.SaveChanges();
        }

    }
}
