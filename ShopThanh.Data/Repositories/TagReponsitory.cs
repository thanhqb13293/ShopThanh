using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface ITagReponsitory
    {
    }

    public class TagReponsitory : RepositoryBase<Footer>, ITagReponsitory
    {
        public TagReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}