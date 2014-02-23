'use strict';

/* Services */
angular.module('myApp.services', [])
  .factory('custDataService', function (breeze) {

      breeze.NamingConvention.camelCase.setAsDefault();
      var serviceName = 'breeze/Customer';
      var manager = new breeze.EntityManager(serviceName);

      return {
          getAllCustomers: getAllCustomers,
          saveChanges: saveChanges,
          getCustomerById: getCustomerById,
          newCustomer: newCustomer,
          deleteCustomer: deleteCustomer
      };
      function deleteCustomer(customer, persist) {
          debugger;
          customer.entityAspect.setDeleted();

          if (persist) {
              saveChanges();
          }
      }

      function getAllCustomers() {
          var query = breeze.EntityQuery.from('Customers');
          return manager.executeQuery(query);
      }

      function getCustomerById(id) {
          return manager.fetchEntityByKey('Customer', id, true /*check cache before querying DB*/);
      }

      function saveChanges() {
          debugger;
          if (manager.hasChanges()) {
              manager.saveChanges().then(function () {
                  console.log('Changes saved.');
              }).catch(function (error) {
                  console.log('Error saving changeset: ' + error);
              });
          }
          else {
              console.log('no changes to save.');
          }
      }

      function newCustomer(customer) {
          return manager.createEntity('Customer', customer);
      }
  });