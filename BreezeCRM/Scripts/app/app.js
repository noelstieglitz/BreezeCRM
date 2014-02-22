'use strict';

var app = angular.module('myApp', [
  'ngRoute',
  'myApp.services',
  'myApp.controllers',
  'breeze.angular',
  'breeze.directives'
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
}]).config(['zDirectivesConfigProvider', configDirective]);

angular.module('myApp')
       .factory('entityManagerFactory', ['breeze', emFactory]);


//Configure the Breeze Validation Directive for bootstrap 2
function configDirective(cfg) {
    // Custom template with warning icon before the error message
    cfg.zValidateTemplate =
       '<span class="invalid"><span style="color: red;" class="glyphicon glyphicon-warning-sign"></span>' +
       ' %error%</span>';
};

function emFactory(breeze) {
    // Convert properties between server-side PascalCase and client-side camelCase
    breeze.NamingConvention.camelCase.setAsDefault();

    // Identify the endpoint for the remote data service
    var serviceName = 'breeze/Customer';

    // the "factory" services exposes two members
    var factory = {
        newManager: function () { return new breeze.EntityManager(serviceName); },
        serviceName: serviceName
    };

    return factory;
};