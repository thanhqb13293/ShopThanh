using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;

namespace ShopThanh.Data.Repositories
{
    public interface IVisistorStatisticReponsitory:IRepository<VisistorStatistic>
    {
    }

    public class VisistorStatisticReponsitory : RepositoryBase<VisistorStatistic>, IVisistorStatisticReponsitory
    {
        public VisistorStatisticReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}