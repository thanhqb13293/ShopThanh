/// <reference path="/Assets/Admin/libs/angular/angular.js" />
(function (app) {
    app.factory('notificationService', notificationService);
    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": "300",
            "fadeOut": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000"
        };
        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayInfo: displayInfo,
            displayWarning: displayWarning
        }
        function displaySuccess(message) {
            toastr.success(message);
        }
        function displayError(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                })
            }
            else
                toastr.error(error);
        }
        function displayWarning(message) {
            toastr.warning(message);
        }
        function displayInfo(info) {
            toastr.info(info);
        }

    }
})(angular.module('shopThanh.common'));