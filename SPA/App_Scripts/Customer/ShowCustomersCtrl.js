//The controller has dependency upon the Service and ShareData
app.controller('ShowCustomersCtrl', function ($scope, $location, ApiService, ShareData) {

    loadRecords();

    //Function to Load all Customers Records.   
    function loadRecords() {
        var promiseGetCustomers = ApiService.getCustomers();

        promiseGetCustomers.then(function (pl) { $scope.Customers = pl.data },
            function (errorPl) {
                $scope.error = 'Failure loading Customer.', errorPl;
            });
    }


    //Method to route to the addcustomer
    $scope.addCustomer = function () {
        $location.path("/addcustomer");
    }

    //Method to route to the view customer
    $scope.view = function (id) {
        ShareData.value = id;
        $location.path("/customer");
    }
});