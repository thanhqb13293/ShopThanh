using ShopThanh.Service;
using ShopThanh.Web.Infrastructure.Core;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using ShopThanh.Model.Models;
using System.Net;
using AutoMapper;
using ShopThanh.Web.Models;
using ShopThanh.Web.Infrastructure.Extension;

namespace ShopThanh.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpRespone(requestMessage, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdaetPostCategory(postCategoryVm);
                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();
                    reponse = Request.CreateResponse(HttpStatusCode.Created, category);
                }
                return reponse;
            });
        }
        [Route("Update")]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpRespone(requestMessage, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var PostCategoryDB = _postCategoryService.GetById(postCategoryVm.ID);
                    PostCategoryDB.UpdaetPostCategory(postCategoryVm);
                    _postCategoryService.Update(PostCategoryDB);
                    _postCategoryService.Save();
                    reponse = Request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            });
        }
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpRespone(requestMessage, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();
                    reponse = Request.CreateResponse(HttpStatusCode.OK);
                }
                return reponse;
            });
        }
        [Route("GetAll")]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreateHttpRespone(requestMessage, () =>
            {
                var lstPostCategory = _postCategoryService.GetAll();
                var lstPostCategoryvm = Mapper.Map<List<PostCategoryViewModel>>(lstPostCategory);
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.OK, lstPostCategory);

                return reponse;
            });
        }

    }
}