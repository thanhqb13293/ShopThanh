/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input) {
                return 'activé';
            }
            else
                return 'bloc';
        }
    });
})(angular.module('shopThanh.common'));