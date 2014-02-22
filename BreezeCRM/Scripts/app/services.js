﻿'use strict';

/* Services */
angular.module('myApp.services', [])
  .factory('custDataService', function (breeze) {

      breeze.NamingConvention.camelCase.setAsDefault();
      var serviceName = 'breeze/Customer';
      var manager = new breeze.EntityManager(serviceName);
      //manager.enableSaveQueuing(true);

      return {
          getAllCustomers: getAllCustomers,
          saveChanges: saveChanges,
          getCustomerById: getCustomerById,
          newCustomer: newCustomer,
          deleteCustomer: deleteCustomer
      };
      function deleteCustomer(customer) {
          customer.entityAspect.setDeleted();
          manager.saveChanges();
      }

      function getAllCustomers() {
          var query = breeze.EntityQuery.from('Customers');
          return manager.executeQuery(query);
      }

      function getCustomerById(id) {
          return manager.fetchEntityByKey('Customer', id, true /*check cache before querying DB*/);
      }

      function saveChanges() {
          manager.saveChanges();
      }

      function newCustomer(customer) {
          return manager.createEntity('Customer', customer);
      }
  });