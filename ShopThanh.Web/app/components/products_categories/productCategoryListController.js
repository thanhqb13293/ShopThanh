﻿/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getproductCategories = getproductCategories;

        function getproductCategories() {
            page = page || 0;
            var config = {
                params:{
                    page: page,
                    pageSize:2
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                $scope.productCategories = result.data.items;
                $scope.page = result.data.page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                
            }, function () {
                Console.log('Load productCategories failed');
            });
        }
        $scope.getproductCategories();
    }
})(angular.module('shopThanh.product_categories'));