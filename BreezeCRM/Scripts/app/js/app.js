'use strict';

angular.module('myApp', [
  'ngRoute',
  'myApp.services',
  'myApp.controllers'
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/customer', { templateUrl: 'partials/CustomerList.html', controller: 'CustomerListController' });
    $routeProvider.when('/order', { templateUrl: 'partials/OrderList.html', controller: 'OrderListController' });
    $routeProvider.otherwise({ redirectTo: '/customer' });
}]).value('breeze', breeze);

