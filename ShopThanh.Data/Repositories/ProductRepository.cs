using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetByAlias(string Alias);
    }
    public class ProductRepository:RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
        public IEnumerable<Product> GetByAlias(string Alias)
        {
            return this.DbContext.Products.Where(n => n.Alias == Alias);
        }
    }
}
