using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace ShopThanh.Service
{
    public interface IPostService
    {
        void AddPost(Post post);

        void Update(Post post);

        void Delete(int Id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        IEnumerable<Post> GetAllByCategoryPaging(int CategoryID,int page, int pageSize, out int totalRow);

        Post GetById(int Id);

        IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        IPostReponsitory _postReponsitory;
        IUnitOfWork _unitOfWork;
        public PostService(IPostReponsitory Post, IUnitOfWork iU)
        {
            _postReponsitory =Post;
            _unitOfWork = iU;
        }
        public void AddPost(Post post)
        {
            _postReponsitory.Add(post);
        }

        public void Delete(int Id)
        {
            _postReponsitory.Delete(Id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postReponsitory.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllByCategoryPaging(int CategoryID, int page, int pageSize, out int totalRow)
        {
            return _postReponsitory.GetMultiPaging(x => x.status && x.CategoryID == CategoryID, out totalRow, page, pageSize,new string[] {"PostCategory" });
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag,int page, int pageSize, out int totalRow)
        {
            //TODO:Get page by tag
            return _postReponsitory.GetAllByTag(tag, page, pageSize,out totalRow);
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _postReponsitory.GetMultiPaging(x => x.status, out totalRow, page, pageSize);
        }

        public Post GetById(int Id)
        {
            return _postReponsitory.GetSingleById(Id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postReponsitory.Update(post);
        }
    }
}