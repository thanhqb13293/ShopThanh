using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Repositories
{
    public interface ISlideReponsitory: IRepository<Slide>
    {
    }

    public class SlideReponsitory : RepositoryBase<Slide>, ISlideReponsitory
    {
        public SlideReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
