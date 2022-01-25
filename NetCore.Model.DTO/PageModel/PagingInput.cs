using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetCore.Model.DTO.PageModel
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PagingInput
    {
        /// <summary>
        /// 每页条目数
        /// </summary>
        public virtual int Size { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public virtual int Number { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual OrderByInput[] Sorts { get; set; }

        /// <summary>
        /// 设置排序
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="page"></param>
        /// <param name="selector"></param>
        /// <param name="isDescending"></param>
        public static void SetSort<TEntity>(PagingInput page, Expression<Func<TEntity, object>> selector, bool isDescending = true)
        {

            page.Sorts = new OrderByInput[] { new OrderByInput { IsDescending = isDescending, PropertyName = GetPropertyName(selector) } };
        }
        /// <summary>
        /// 获取属性名
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static string GetPropertyName<TModel, TResult>(Expression<Func<TModel, TResult>> selector)
        {
            if (selector.Body is MemberExpression)
                return ((MemberExpression)selector.Body).Member.Name;
            if (selector.Body is UnaryExpression)
                return ((selector.Body as UnaryExpression).Operand as MemberExpression).Member.Name;
            throw new NotSupportedException(string.Format("属性选择表达式{0}不正确", selector));
        }
    }
}
