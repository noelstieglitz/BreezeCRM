'use strict';

/* Services */
angular.module('myApp.services', [])
  .factory('custDataService', function (breeze) {

      breeze.NamingConvention.camelCase.setAsDefault();
      var serviceName = 'breeze/Customer';
      var manager = new breeze.EntityManager(serviceName);
      //manager.enableSaveQueuing(true);

      return {
          getAllCustomers: getAllCustomers,
          createCustomer: createCustomer,
          getCustomerById: getCustomerById
      };

      function getAllCustomers() {
          var query = breeze.EntityQuery.from('Customers');
          return manager.executeQuery(query);
      }

      function getCustomerById(id) {
          debugger;
          //return manager.fetchEntityByKey('Customer', id, true /*check cache before querying DB*/);
          //return manager.fetchEntityByKey('Customer', id);
          //manager.fetchEntityByKey("Customer", id)
          //    .then(function (data) {
          //    debugger;
          //        return data.entity;
          //    });
          //TODO - refactor to use fromEntityKey and return data instead of promise
          var query = breeze.EntityQuery.from('Customers').where('customerID', 'eq', id);
          return manager.executeQuery(query);
      }
      function createCustomer(customerId, companyName) { //TODO - pass a VM to the service

          if (!manager.metadataStore.isEmpty()) {
              debugger;//why?
          }
          var newEntity = manager.createEntity('Customer', { customerID: customerId, companyName: companyName });
          manager.saveChanges();
          return newEntity;
      }
  });