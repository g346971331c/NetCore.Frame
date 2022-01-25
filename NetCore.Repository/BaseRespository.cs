using Infrastructure;
using Microsoft.EntityFrameworkCore;
using NetCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Repository
{
    public class BaseRespository<T> : IRespository<T> where T : BaseEntitys.EntityBase
    {

        private DataDBContext _context { get; set; }

        public BaseRespository(DataDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 根据过滤条件，查询记录
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> exp = null)
        {
            return Filter(exp);
        }

        public T FindSingle(Expression<Func<T, bool>> exp = null)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(exp);
        }


        public IQueryable<T> Filter(Expression<Func<T, bool>> exp)
        {
            var dbSet = _context.Set<T>().AsNoTracking().AsQueryable();
            if (exp != null)
                dbSet = dbSet.Where(exp);

            return dbSet;
        }


        #region 异步

        /// <summary>
        /// 异步查询
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> exp = null)
        {
            return await Task.FromResult(Filter(exp));
        }

        /// <summary>
        /// 查询单个对象
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual async Task<T> FindSingleAsync(Expression<Func<T, bool>> exp = null)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(exp);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task AddAsync(T entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            if (!_context.ChangeTracker.HasChanges())
            {
                await Task.CompletedTask;
            }
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 按条件更新(未实现)
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(Expression<Func<T, bool>> exp)
        {
            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        #endregion


    }
}
