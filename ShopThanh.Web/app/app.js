
(function () {
    angular.module('shopThanh', ['shopThanh.common', 'shopThanh.products']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeVIew.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();