'use strict';

angular.module('myApp.controllers', [])
    .controller('CustomerListController', ['$scope', 'custDataService', function ($scope, custDataService) {

        custDataService.getAllCustomers()
            .then(function (data) {
                $scope.customers = data.results;
            })
            .catch(function (error) {
                console.log("Error calling api: " + error.message);
            });
    }]).controller('OrderListController', ['$scope', 'custDataService', function ($scope, custDataService) {
        //TODO
        $scope.orders = [{ 'DateOrdered': '11/11/2013', 'OrderNumber': '12345' }];

    }]).controller('EditCustomerController', ['$scope', '$location', '$routeParams', 'custDataService', function ($scope, $location, $routeParams, custDataService) {

        custDataService.getCustomerById($routeParams.customerId)
            .then(function (data) {
                //TODO - refactor to use fromEntityKey (which won't return results[0])
                $scope.customer = data.results[0];
        });

        $scope.destroy = function () {
            //TODO - discard changes?
            $location.path('/');
        };

        $scope.save = function () {
            //TODO
            $location.path('/');
        };
    }]).controller('CreateCustomerController', ['$scope', '$location', 'custDataService', function ($scope, $location, custDataService) {
        $scope.destroy = function () {
            debugger;
            $scope.customer.$remove();
            $location.path('/');
        };

        $scope.save = function () {
            debugger;
            custDataService.createCustomer($scope.customer.customerId, $scope.customer.companyName);
            $location.path('/');
        };
    }]);