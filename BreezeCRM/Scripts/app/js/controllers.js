'use strict';

/* Controllers */

angular.module('myApp.controllers', []).
  controller('CustomerListController', ['$scope', 'custDataService', function ($scope, custDataService) {

      //$scope.customers = [{ "FirstName": "What", "LastName": "Huh" }];

      $scope.customers = 
          custDataService.getAllCustomers();
}]);