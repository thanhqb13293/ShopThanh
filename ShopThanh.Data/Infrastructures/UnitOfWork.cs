using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private ShopThanhDbContext dbContext;

        public UnitOfWork(IDbFactory IdbFactory)
        {
            this.dbFactory = IdbFactory;
        }

        public ShopThanhDbContext DbContext
        {
            get{ return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}