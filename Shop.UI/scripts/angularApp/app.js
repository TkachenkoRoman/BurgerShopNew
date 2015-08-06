angular.module('burgerShop', ['ngRoute']).config(['$routeProvider', function ($routeProvider) {
    $routeProvider 
    .when('/food', {
        templateUrl: '../templates/products.html',
        controller: 'storeController',
    })
    .when('/shoppingCart', {
        templateUrl: '../templates/shoppingCart.html',
        controller: 'storeController'
    })
    .when('/', {
        redirectTo: '/food'
    });
}]);

// create a data service that provides a store and a shopping cart that
// will be shared by all views (instead of creating fresh ones for each view).
angular.module('burgerShop').factory("StoreService", function () {

    // create store
    //var myStore = new store();

    // create shopping cart
    var myCart = new shoppingCart("BurgerShop");

    // return data object with store and cart
    return {
        //store: myStore,
        cart: myCart
    };
});

angular.module('burgerShop').factory("DataService", ['$http', function ($http) {

    return {
        products: function () {
            var promise = $http.get('http://localhost:8080/api/products').success(function (data) {
                //console.log('success');
                return data;
            });
            return promise;
        }
    };
}]);