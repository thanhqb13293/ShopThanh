using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        void Update(ProductCategory productCategory);

        ProductCategory Delete(int Id);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAllByParentID(int ParentId);

        ProductCategory GetById(int Id);
        void Save();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProducCategoryRepository _productCategoryReponsitory;
        IUnitOfWork _unitOfWork;
        public ProductCategoryService(IProducCategoryRepository PostCategory, IUnitOfWork iU)
        {
            _productCategoryReponsitory = PostCategory;
            _unitOfWork = iU;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryReponsitory.Add(productCategory);
        }

        public ProductCategory Delete(int Id)
        {
            return _productCategoryReponsitory.Delete(Id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryReponsitory.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByParentID(int ParentId)
        {
            return _productCategoryReponsitory.GetMulti(x => x.status && x.ParentID == ParentId);
        }

        public ProductCategory GetById(int Id)
        {
            return _productCategoryReponsitory.GetSingleById(Id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory productCategory)
        {
            _productCategoryReponsitory.Update(productCategory);
        }
    }
}
