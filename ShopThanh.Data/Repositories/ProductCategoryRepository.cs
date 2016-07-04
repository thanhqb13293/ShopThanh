using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Repositories
{
    //Definition toutes les méthodes ne sont pas dans RepositoryBase
    public interface IProducCategoryRepository
    {
        IEnumerable<ProductCategory> GetByAlias(string Alias);
    }
    public class ProductCategoryRepository:RepositoryBase<ProductCategory>, IProducCategoryRepository
    {       
        public ProductCategoryRepository(IDbFactory dbFactory):base(dbFactory)
        {

        }
        public IEnumerable<ProductCategory> GetByAlias(string Alias)
        {
            return this.DbContext.ProductCategories.Where(n => n.Alias == Alias);
        }
    }
}
