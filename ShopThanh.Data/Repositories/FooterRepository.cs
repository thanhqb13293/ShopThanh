using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface IFooterReponsitory
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterReponsitory
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}