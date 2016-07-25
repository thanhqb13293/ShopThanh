/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.filter('statusFilter', statusFilter);
    function statusFilter() {
        return function (input) {
            if (input == true) {
                return 'activé';
            }
            else
                return 'bloqué';
        }
    };
})(angular.module('shopThanh.common'));