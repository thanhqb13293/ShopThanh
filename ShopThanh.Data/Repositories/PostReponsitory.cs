using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopThanh.Data.Repositories
{
    public interface IPostReponsitory: IRepository<Post>
    {
        IEnumerable<Post> GetByAlias(string Alias);

        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostReponsitory : RepositoryBase<Post>, IPostReponsitory
    {
        public PostReponsitory(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var querry = from p in DbContext.Posts
                         join pt in DbContext.PostTags
                         on p.ID equals pt.PostID
                         where pt.TagID == tag && p.status
                         orderby p.CreateDate descending
                         select p;
            totalRow = querry.Count();
            querry = querry.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return querry;
        }

        public IEnumerable<Post> GetByAlias(string Alias)
        {
            return this.DbContext.Posts.Where(n => n.Alias == Alias);
        }
    }
}