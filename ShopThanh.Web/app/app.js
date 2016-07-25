/// <reference path="/Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('shopThanh', ['shopThanh.common', 'shopThanh.products','shopThanh.product_categories']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();