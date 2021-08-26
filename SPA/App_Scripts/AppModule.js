var app = angular.module("ApplicationModule", ["ngRoute"]);

//The Factory used to define the value to
//Communicate and pass data across controllers
app.factory("ShareData", function () {
    return { value: 0 }
});

//Defining Routing
app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/showcustomers',
        {
            templateUrl: 'Customer/ShowCustomers',
            controller: 'ShowCustomersCtrl'
        });
    $routeProvider.when('/addcustomer',
        {
            templateUrl: 'Customer/AddCustomer',
            controller: 'AddCustomerCtrl'
        });
    $routeProvider.when('/customer',
        {
            templateUrl: 'Customer/EditCustomer',
            controller: 'EditCustomerCtrl'
        });
    $routeProvider.otherwise(
        {
            redirectTo: '/'
        });
    $locationProvider.html5Mode(true).hashPrefix('!')
}]);