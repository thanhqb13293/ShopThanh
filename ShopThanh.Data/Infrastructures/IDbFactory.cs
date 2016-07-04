using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Infrastructures
{
    public interface IDbFactory:IDisposable
    {
        ShopThanhDbContext Init();
    }
}
