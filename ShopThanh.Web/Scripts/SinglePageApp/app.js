var myApp = angular.module('myModule', []);

myApp.controller("myController", myController)
myApp.service('Validator',Validator);

myController.$inject = ['$scope','Validator'];


function myController($scope,Validator) {
    Validator.CheckN(2);
}


function Validator($window) {
    return{
        CheckN:CheckNumber
    }
    function CheckNumber(input) {
        if (input % 2==0) {
            $window.alert('THis is a even');}
        else
            $window.alert('THis is a odd');
    }
}
