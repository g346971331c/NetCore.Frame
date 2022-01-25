using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.Repository.Interface
{
    public interface IRespository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> exp = null);

        IQueryable<T> Find(Expression<Func<T, bool>> exp = null);


        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> exp = null);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> exp = null);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task UpdateAsync(Expression<Func<T, bool>> exp);

        Task DeleteAsync(T entity);
    }
}
