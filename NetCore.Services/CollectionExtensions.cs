using NetCore.Model.DTO.PageModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetCore.Services
{
    public static class CollectionExtensions
    {
        const string REQUIRED_SORTS_ARGS = "必须指定排序";
        const string ORDERBY_COMMAND = "OrderBy";
        const string ORDERBYDESC_COMMAND = "OrderByDescending";
        const string THENORDERBY_COMMAND = "ThenBy";
        const string THENORDERBYDESC_COMMAND = "ThenByDescending";
        public static PagingCollection<TEntity> Page<TEntity>(this IQueryable<TEntity> source, PagingInput pagingReq)
        {

            if (pagingReq.Size < 1)
                throw new NotSupportedException("Page Size必须大于0");
            if (pagingReq.Number < 1)
                pagingReq.Number = 1;
            IQueryable<TEntity> queryable = source.OrderBys(pagingReq.Sorts).Skip(pagingReq.Size * (pagingReq.Number - 1)).Take(pagingReq.Size);
            return new PagingCollection<TEntity> { Count = source.Count(), Size = pagingReq.Size, Number = pagingReq.Number, Sorts = pagingReq.Sorts, Items = queryable.ToArray() };
        }
        private static IOrderedQueryable<TEntity> OrderBys<TEntity>(this IQueryable<TEntity> source, params OrderByInput[] sorts)
        {
            if (sorts.Length == 0)
                throw new NotImplementedException(REQUIRED_SORTS_ARGS);
            Expression queryExpr = source.Expression;
            var orderByAsc = ORDERBY_COMMAND;
            var orderByDesc = ORDERBYDESC_COMMAND;
            for (var i = 0; i < sorts.Length; i++)
            {
                var orderBy = sorts[i];
                string command = orderBy.IsDescending ? orderByDesc : orderByAsc;
                var type = typeof(TEntity);
                var property = type.GetProperty(orderBy.PropertyName);
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);
                queryExpr = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType }, queryExpr, Expression.Quote(orderByExpression));
                orderByAsc = THENORDERBY_COMMAND;
                orderByDesc = THENORDERBYDESC_COMMAND;
            }
            return source.Provider.CreateQuery<TEntity>(queryExpr) as IOrderedQueryable<TEntity>;
        }
    }
}
