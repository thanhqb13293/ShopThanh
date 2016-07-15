using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
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

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            //On a créé un category, ensuite faut remplir les champs not null for this instance
            category.Name = "Test category";
            category.Alias = "Test-Category";
            category.status = true;
            var result = objRepository.Add(category);
            UnitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.ID);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();

            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
        }
    }
}
