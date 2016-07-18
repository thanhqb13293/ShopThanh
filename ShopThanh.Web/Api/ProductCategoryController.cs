using AutoMapper;
using ShopThanh.Service;
using ShopThanh.Web.Infrastructure.Core;
using ShopThanh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopThanh.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpRespone(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(model);
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.OK, model);

                return reponse;
            });
        }
    }
}
