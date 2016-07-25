/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService','notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getproductCategories = getproductCategories;
        $scope.keyword = '';

        $scope.search = search;
        function search() {
            getproductCategories();
        }
        function getproductCategories(page) {

            page = page || 0;
            var config = {
                params: {
                    keyword:$scope.keyword,
                    page: page,
                    pageSize:2
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.totalCount==0) {
                    notificationService.displayWarning('Khong tim thay ban ghi nao');
                }
                else
                {
                    notificationService.displaySuccess('Tim thay' + result.data.totalCount + ' items');
                }
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