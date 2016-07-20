/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoriesListController', productCategoriesListController);
    productCategoriesListController.$inject = ['$scope','apiService'];

    function productCategoriesListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getproductCategories = getproductCategories;
        function getproductCategories() {
            apiService.get('/api/productCategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                Console.log('Load productCategory failed');
            });
        }
        $scope.getproductCategories();
    }
})(angular.module('shopThanh.product_categories'));