'use strict';

/* Services */
angular.module('myApp.services', [])
  .factory('custDataService', function(breeze) {

    breeze.config.initializeAdapterInstance("modelLibrary", "backingStore", true);

    var serviceName = 'breeze/Customer';
    var manager = new breeze.EntityManager(serviceName);
    //manager.enableSaveQueuing(true);

    return {
        getAllCustomers: getAllCustomers
    };

    function getAllCustomers() {
        var query = breeze.EntityQuery
                .from("Customers");

        return manager.executeQuery(query);
    }
});