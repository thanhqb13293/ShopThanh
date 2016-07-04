using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Infrastructures
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteMulti(Expression<Func<T, bool>> where);
        T GetSingleById(int Id);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] include = null);
        IQueryable<T> GetAll(string[] include = null);
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] include = null);
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] include = null);
        int Count(Expression<Func<T, bool>> where);
        bool CheckContent(Expression<Func<T, bool>> predicate);
    }
}
