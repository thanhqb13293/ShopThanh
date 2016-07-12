using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
using ShopThanh.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _lstPostCategory;
        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _lstPostCategory = new List<PostCategory>()
            {
                new PostCategory() { ID=1,Name="DM1",status=true},
                new PostCategory() { ID=2,Name="DM2",status=true},
                new PostCategory() { ID=3,Name="DM3",status=true},
            };
        }

        [TestMethod]
        public void PostCategory_Service_Test_GetAll()
        {
            //Setup Methode
            _mockRepository.Setup(n => n.GetAll(null)).Returns(_lstPostCategory);
            //callAction
            var result = _categoryService.GetAll() as List<PostCategory>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Test_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test";
            category.Alias = "Test";
            category.status = true;

            //Setup mock
            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
            {
                p.ID = 1;
                return p;
            });
            var result = _categoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
    }
}
