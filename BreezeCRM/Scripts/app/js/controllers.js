'use strict';

angular.module('myApp.controllers', [])
    .controller('CustomerListController', ['$scope', 'custDataService', function ($scope, custDataService) {

        custDataService.getAllCustomers($scope)
            .then(function (data) {
                $scope.customers = data.results;
            })
            .fail(function (error) {
                console.log("Error calling api: " + error.message);
            }).fin(function () {
                $scope.$apply();
            });
    }]).controller('OrderListController', ['$scope', 'custDataService', function ($scope, custDataService) {

        $scope.orders = [{ 'DateOrdered': '11/11/2013', 'OrderNumber': '12345' }];

    }]);