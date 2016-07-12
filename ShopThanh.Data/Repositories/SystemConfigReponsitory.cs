using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface ISystemConfigReponsitory: IRepository<SystemConfig>
    {
    }

    public class SystemConfigReponsitory : RepositoryBase<SystemConfig>, ISystemConfigReponsitory
    {
        public SystemConfigReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}