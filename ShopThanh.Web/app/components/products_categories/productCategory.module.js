/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    angular.module('shopThanh.product_categories', ['shopThanh.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/products",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });
    }
})();