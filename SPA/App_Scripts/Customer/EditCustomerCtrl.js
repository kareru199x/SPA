app.controller("EditCustomerCtrl", function ($scope, $location, ShareData, ApiService) {

    getCustomer();

    function getCustomer() {

        var promiseGetCustomer = ApiService.getCustomer(ShareData.value);

        promiseGetCustomer.then(function (pl) {
            $scope.Customer = pl.data;
        },
            function (errorPl) {
                $scope.error = 'failure loading Customer', errorPl;
            });
    }

    $scope.close = function () {
        $location.url('/showcustomers');
    }
});