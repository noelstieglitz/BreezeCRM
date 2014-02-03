'use strict';

/* Services */
angular.module('myApp.services', [])
  .factory('custDataService', function(breeze) {

    //breeze.config.initializeAdapterInstance("modelLibrary", "backingStore", true);
    breeze.config.initializeAdapterInstances({ dataService: "webApi" });
    var serviceName = 'odata/';

    var manager = new breeze.EntityManager(serviceName);
    //manager.enableSaveQueuing(true);

    return {
        getAllCustomers: getAllCustomers
    };

    function getAllCustomers() {
        var query = breeze.EntityQuery
                .from("Customers")
                .orderBy("LastName");

        return manager.executeQuery(query);
    }
});