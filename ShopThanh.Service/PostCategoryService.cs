﻿using ShopThanh.Data.Infrastructures;
using ShopThanh.Data.Repositories;
using ShopThanh.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopThanh.Service
{
    public interface IPostCategoryService
    {
        void AddPost(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int Id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentID(int ParentId);

        PostCategory GetById(int Id);
        void Save();
    }
    public class PostCategoryService:IPostCategoryService
    {
        PostCategoryRepository _postCategoryReponsitory;
        IUnitOfWork _unitOfWork;
        public PostCategoryService(PostCategoryRepository PostCategory, IUnitOfWork iU)
        {
            _postCategoryReponsitory = PostCategory;
            _unitOfWork = iU;
        }

        public void AddPost(PostCategory postCategory)
        {
            _postCategoryReponsitory.Add(postCategory);
        }

        public void Delete(int Id)
        {
            _postCategoryReponsitory.Delete(Id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryReponsitory.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentID(int ParentId)
        {
            return _postCategoryReponsitory.GetMulti(x => x.status && x.ParentID == ParentId);
        }

        public PostCategory GetById(int Id)
        {
            return _postCategoryReponsitory.GetSingleById(Id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            _postCategoryReponsitory.Update(postCategory);
        }
    }
}