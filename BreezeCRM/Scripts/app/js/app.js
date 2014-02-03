'use strict';

angular.module('myApp', [
  'ngRoute',
  'myApp.services',
  'myApp.controllers'
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/customer', { templateUrl: 'partials/CustomerList.html', controller: 'CustomerListController' });
    $routeProvider.otherwise({ redirectTo: '/customer' });
}]).value('breeze', breeze);