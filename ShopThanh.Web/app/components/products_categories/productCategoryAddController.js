/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryAddController', productCategoryAddController);
    productCategoryAddController.$inject = ['apiService','$scope','notificationService'];
    function productCategoryAddController(apiService, $scope, notificationService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status:true
        }
        $scope.parentCategories = [];
        $scope.AddProductCategory = AddProductCategory;
        function AddProductCategory() {
            apiService.post('api/productcategory/create', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' was created');
                $state.go('product_categories');
            }, function (error) {
                if (error.status===401) {
                    notificationService.displayError('Create item not success');
                }
                else if (failure!=null) {
                    failure(error);
                }
            });
        }
        function loadParentCategories() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadParentCategories();
    }
})(angular.module('shopThanh.product_categories'));