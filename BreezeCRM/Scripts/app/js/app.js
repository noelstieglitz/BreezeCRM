'use strict';

var app = angular.module('myApp', [
  'ngRoute',
  'myApp.services',
  'myApp.controllers',
  'breeze.angular.q' // tells breeze to use $q instead of Q.js
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/customer', {
            templateUrl: 'partials/CustomerList.html',
            controller: 'CustomerListController'
        })
        .when('/order', {
            templateUrl: 'partials/OrderList.html',
            controller: 'OrderListController'
        })
        .when('/edit/:customerId', {
            controller: 'EditCustomerController',
            templateUrl: 'partials/EditCustomer.html'
        })
        .when('/new', {
            controller: 'CreateCustomerController',
            templateUrl: 'partials/EditCustomer.html'
        })
        .otherwise({ redirectTo: '/customer' });
}]).value('breeze', breeze);

app.run(['$q', 'use$q', function ($q, use$q) {
    use$q($q); //now we don't need the Q.js dependency
}]);