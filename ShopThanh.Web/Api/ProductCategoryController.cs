using AutoMapper;
using ShopThanh.Model.Models;
using ShopThanh.Service;
using ShopThanh.Web.Infrastructure.Core;
using ShopThanh.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopThanh.Web.Infrastructure.Extension;

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
        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpRespone(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newproductCategory = new ProductCategory();
                    newproductCategory.UpdaetProductCategory(productCategoryVm);
                    _productCategoryService.Add(newproductCategory);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newproductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);                    
                }
                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpRespone(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll(keyword);
                totalRow = model.Count();
                var querry = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(querry);
                var paginationSet = new paginationSet<ProductCategoryViewModel>()
                {
                    items = responseData,
                    Page = page,
                    TotalPages = totalRow,
                    TotalCount = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return reponse;
            });
        }
        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAllParent(HttpRequestMessage request)
        {
            return CreateHttpRespone(request, () =>
            {
                var model = _productCategoryService.GetAll();
                var responseData = Mapper.Map<List<ProductCategoryViewModel>>(model);
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.OK, responseData);

                return reponse;
            });
        }
    }
}
