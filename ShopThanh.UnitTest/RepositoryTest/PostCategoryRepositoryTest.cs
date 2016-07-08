using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IUnitOfWork UnitOfWork;
        IPostCategoryRepository objRepository;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            UnitOfWork = new UnitOfWork(dbFactory);
        }
    }
}
