using NetCore.Repository;
using NetCore.Repository.BaseEntitys;
using NetCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Services
{
    public class BaseServices<T> where T : EntityBase
    {
        protected IRespository<T> Respository;

        public BaseServices(IRespository<T> baseRespository)
        {
            Respository = baseRespository;
        }


        public T Get(string id)
        {
            return Respository.FindSingle(u => u.Id == id);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> exp)
        {
            return Respository.Find(exp);
        }


        //异步方法

        public Task<IQueryable<T>> ListAsync(Expression<Func<T, bool>> exp)
        {
            // return BaseRespository.find
            return null;
        }
    }
}
