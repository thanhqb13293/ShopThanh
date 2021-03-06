﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Infrastructures
{
    public abstract class RepositoryBase<T>:IRepository<T> where T :class
    {
        #region Proprietes
        private ShopThanhDbContext dataContext;
        private readonly IDbSet<T> dbSet;
        protected IDbFactory DbFacory { get; private set; }
        #endregion
        protected ShopThanhDbContext DbContext
        {
            get{ return dataContext ?? (dataContext = DbFacory.Init()); }
        }
        public RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFacory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }
        public virtual void DeleteMulti(Expression<Func<T,bool>> where)
        {
            IEnumerable<T> objets = dbSet.Where<T>(where).AsEnumerable();
            foreach (T objet in objets)
                dbSet.Remove(objet);
        }
        public T GetSingleById(int Id)
        {
            return dbSet.Find(Id);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string include)
        {
            return dbSet.Where(where).ToList();
        }
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }
        public IEnumerable<T> GetAll(string[] includes=null)
        {
            if (includes!=null&& includes.Count()>0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                    return query.AsQueryable();
                }
            }
            return dataContext.Set<T>().AsQueryable();
        }
        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                    return query.Where<T>(predicate).AsQueryable<T>();
                }
            }
            return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }
        //public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null)
        //{
        //    int skipCount = index * size;
        //    IQueryable<T> _resetSet;
        //    if (includes!=null && includes.Count()>0)
        //    {
        //        var query = dataContext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //        {
        //            query = query.Include(include);
        //            _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable<T>() : query.AsQueryable();
        //        }
        //    }
        //    else
        //    {
        //        _resetSet = predicate != null ? dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>() : dataContext.Set<T>().AsQueryable();
        //    }
        //    _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //    total = _resetSet.Count();

        //    return _resetSet.AsQueryable();
        //}
        public virtual bool CheckContent(Expression<Func<T, bool>> predicate)
        {
            return dataContext.Set<T>().Count<T>(predicate) > 0;
        }
        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                {
                    query = query.Include(include);
                    return query.FirstOrDefault(expression);
                }
            }
            return dataContext.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] include = null)
        {
            throw new NotImplementedException();
        }

        public virtual T Delete(int Id)
        {
            var entity = dbSet.Find(Id);
            return dbSet.Remove(entity);
        }
    }
}
