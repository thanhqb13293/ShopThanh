using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface ITagReponsitory: IRepository<Tag>
    {
    }

    public class TagReponsitory : RepositoryBase<Tag>, ITagReponsitory
    {
        public TagReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}