app.service("ApiService", function ($http) {

    //Function to Read All Customers
    this.getCustomers = function () {
        return $http.get("/api/CustomerAPI");
    };

    //Fundction to Read Customer based upon id
    this.getCustomer = function (id) {
        return $http.get("/api/CustomerAPI/" + id);
    };

    //Function to create new Customer
    this.post = function (Customer) {
        var request = $http({
            method: "post",
            url: "/api/CustomerAPI",
            data: Customer
        });
        return request;
    };

    //Function  to Update Customer based upon id 
    this.put = function (id, Customer) {
        var request = $http({
            method: "put",
            url: "/api/CustomerAPI/" + id,
            data: Customer
        });
        return request;
    };

    //Function to Delete Customer based upon id
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/CustomerAPI/" + id
        });
        return request;
    };
});