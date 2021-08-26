app.controller('AddCustomerCtrl', function ($scope, $location, ApiService) {
    $scope.Id = 0;

    //The Save scope method used to define the Customer object and 
    //post the Customer information to the server by making call to the API Service
    $scope.save = function () {
        var Customer = {
            Id: $scope.Id,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            BirthDate: $scope.BirthDate,
            Email: $scope.Email,
            PhoneNumber: $scope.PhoneNumber,
            Address: $scope.Address
        };

        var promisePost = ApiService.post(Customer);

        promisePost.then(function (pl) {
            $scope.Id = pl.data.Id;
            alert("Successfully saved customer.");

            $location.url("/showcustomers");
        },function (errorPl) {
            alert(errorPl.data.Message);
        });
    };

    $scope.cancel = function () {
        $location.url("/showcustomers");
    }
});