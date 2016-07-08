using ShopThanh.Service;
using ShopThanh.Web.Infrastructure.Core;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using ShopThanh.Model.Models;
using System.Net;

namespace ShopThanh.Web.Api
{
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService,IPostCategoryService postCategoryService) :base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        public HttpResponseMessage Create(HttpRequestMessage requestMessage,PostCategory postCategory)
        {
            return CreateHttpRespone(requestMessage, () =>
            {
                HttpResponseMessage reponse = null;
                if(!ModelState.IsValid)
                {
                    Request.CreateErrorResponse(HttpStatusCode.BadRequest,ModelState);
                }
                else
                {
                    _postCategoryService.AddPost(postCategory);
                    _postCategoryService.Save();
                    reponse = Request.CreateResponse(HttpStatusCode.Created);
                }
                return reponse;
            });
        }
        
    }
}