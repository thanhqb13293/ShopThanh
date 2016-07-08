using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface IProductTagReponsitory
    {
    }

    public class ProductTagReponsitory : RepositoryBase<ProductTag>, IProductTagReponsitory
    {
        public ProductTagReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}