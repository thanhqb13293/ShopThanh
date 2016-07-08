using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface ISupportOnlineReponsitory
    {
    }

    public class SupportOnlineReponsitory : RepositoryBase<SupportOnline>, ISupportOnlineReponsitory
    {
        public SupportOnlineReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}