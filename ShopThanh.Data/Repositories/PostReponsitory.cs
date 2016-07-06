using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Repositories
{
    public interface IPostReponsitory
    {
        IEnumerable<Post> GetByAlias(string Alias);
    }
    public class PostReponsitory : RepositoryBase<Post>, IPostReponsitory
    {
        public PostReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public IEnumerable<Post> GetByAlias(string Alias)
        {
            return this.DbContext.Posts.Where(n => n.Alias == Alias);
        }
    }
}
