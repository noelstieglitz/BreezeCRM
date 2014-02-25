'use strict';

/* Services */
angular.module('crmApp.services', [])
  .factory('custDataService', function (breeze) {

      breeze.NamingConvention.camelCase.setAsDefault();
      var serviceName = 'breeze/Customer';
      var manager = new breeze.EntityManager(serviceName);

      return {
          getAllCustomers: getAllCustomers,
          saveChanges: saveChanges,
          getCustomerById: getCustomerById,
          newCustomer: newCustomer,
          deleteCustomer : deleteCustomer
      };

      function deleteCustomer(customer, persist) {

          customer.entityAspect.setDeleted();

          if (persist) {
              saveChanges();
          }

      }

      function getAllCustomers(criteria, sort, page) {
          var query = breeze.EntityQuery.from('Customers');

          if (criteria) {
              if (criteria.customerID) {
                  query = query.where('customerID', 'eq', criteria.customerID);
              }
              if (criteria.contactName) {
                  query = query.where('contactName', 'Contains', criteria.contactName);
              }
              if (criteria.minFreightCost) {
                  query = query.where('orders', 'any', 'freight', '>', criteria.minFreightCost);
              }
          }

          //sort
          if (sort) {
              query = query.orderBy(sort);
          } else {
              query = query.orderBy('companyName');
          }

          //page
          if (page) {
              query = query.skip(5 * (page-1));
          }
          query = query.take(5).inlineCount(); //paging

          //projection
          //query = query.select('customerID, contactName, country, phone, fax');
          
          //eager load
          //query = query.expand('orders');

          return manager.executeQuery(query);
      }

      function getCustomerById(id) {
          return manager.fetchEntityByKey('Customer', id, true /*check cache before querying DB*/);
      }

      function saveChanges() {
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