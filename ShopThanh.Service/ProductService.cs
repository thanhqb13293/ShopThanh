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
    public interface IProductService
    {
        void AddPost(Product post);

        void Update(Product post);

        void Delete(int Id);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);

        Product GetById(int Id);

        IEnumerable<Product> GetAllByTagPaging(int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class ProductService : IProductService
    {
        IProductRepository _productReponsitory;
        IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository Product, IUnitOfWork iU)
        {
            _productReponsitory = Product;
            _unitOfWork = iU;
        }
        public void AddPost(Product product)
        {
            _productReponsitory.Add(product);
        }

        public void Delete(int Id)
        {
            _productReponsitory.Delete(Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productReponsitory.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<Product> GetAllByTagPaging(int page, int pageSize, out int totalRow)
        {
            //TODO:Get page by tag
            return _productReponsitory.GetMultiPaging(x => x.status, out totalRow, page, pageSize);
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _productReponsitory.GetMultiPaging(x => x.status, out totalRow, page, pageSize);
        }

        public Product GetById(int Id)
        {
            return _productReponsitory.GetSingleById(Id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _productReponsitory.Update(product);
        }
    }
}
