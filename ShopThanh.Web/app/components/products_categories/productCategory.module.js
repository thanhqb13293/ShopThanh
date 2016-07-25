/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function () {
    angular.module('shopThanh.product_categories', ['shopThanh.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/products_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        })
        .state('add_product_category', {
            url: "/add_product_category",
            templateUrl: "/app/components/products_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        });
    }
})();