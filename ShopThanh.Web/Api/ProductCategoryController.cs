﻿using AutoMapper;
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
        public HttpResponseMessage GetAll(HttpRequestMessage request,int page,int pageSize=20)
        {
            return CreateHttpRespone(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll();
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
    }
}