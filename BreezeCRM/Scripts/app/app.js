'use strict';

var app = angular.module('crmApp', [
  'ngRoute',
  'crmApp.services',
  'crmApp.controllers',
  'breeze.angular',
  'breeze.directives',
  'ui.bootstrap'
]).
config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/customer', {
            templateUrl: 'partials/CustomerList.html',
            controller: 'CustomerListController'
        })
        .when('/customer/:customerId/edit', {
            controller: 'EditCustomerController',
            templateUrl: 'partials/EditCustomer.html'
        })
        .when('/customer/new', {
            controller: 'CreateCustomerController',
            templateUrl: 'partials/EditCustomer.html'
        })
        .otherwise({ redirectTo: '/customer' });
}]).config(['zDirectivesConfigProvider', configDirective]); //configure breeze validation directive

angular.module('crmApp')
       .factory('entityManagerFactory', ['breeze', emFactory]); //breeze service


//Configure the Breeze Validation Directive for bootstrap 3
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