using ShopThanh.Model.Models;
using ShopThanh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThanh.Web.Infrastructure.Extension
{
    public static class EntityExtensions
    {
        public static void UpdaetPostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Image = postCategoryVm.Image;
            postCategory.Description = postCategoryVm.Description;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;
            postCategory.CreateDate = postCategoryVm.CreateDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdateDate = postCategoryVm.UpdateDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyWord = postCategoryVm.MetaKeyWord;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.status = postCategoryVm.status;
        }
        public static void UpdaetPost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.Image = postVm.Image;
            post.CategoryID = postVm.CategoryID;
            post.Content = postVm.Image;
            post.Description = postVm.Description;
            post.HomeFlag = postVm.HomeFlag;
            post.HotFlag = postVm.HotFlag;
            post.ViewCount = postVm.ViewCount;
            post.CreateDate = postVm.CreateDate;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdateDate = postVm.UpdateDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyWord = postVm.MetaKeyWord;
            post.MetaDescription = postVm.MetaDescription;
            post.status = postVm.status;
        }
    }
}