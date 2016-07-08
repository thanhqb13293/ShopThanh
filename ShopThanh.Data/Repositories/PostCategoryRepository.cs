using ShopThanh.Data.Infrastructures;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Data.Repositories
{
    //Definition toutes les méthodes ne sont pas dans RepositoryBase
    public interface IPostCategoryRepository
    {
        IEnumerable<PostCategory> GetByAlias(string Alias);
    }
    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public IEnumerable<PostCategory> GetByAlias(string Alias)
        {
            return this.DbContext.PostCategories.Where(n => n.Alias == Alias);
        }
    }

}
