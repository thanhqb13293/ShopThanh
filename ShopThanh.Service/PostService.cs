using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;

namespace ShopThanh.Service
{
    public interface IPostService
    {
        void AddPost(Post post);

        void Update(Post post);

        void Delete(int Id);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow);

        Post GetById(int Id);

        IEnumerable<Post> GetAllByTagPaging(int page, int pageSize, out int totalRow);

        void SaveChanges();
    }

    public class PostService : IPostService
    {
        PostReponsitory _postReponsitory;
        IUnitOfWork _unitOfWork;
        public PostService(PostReponsitory Post, IUnitOfWork iU)
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

        public IEnumerable<Post> GetAllByTagPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}