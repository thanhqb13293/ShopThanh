/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('shopThanh.product_categories', ['shopThanh.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/products_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });
    }
})();