angular.module('burgerShop', ['ngRoute']).config(['$routeProvider', function ($routeProvider) {
    $routeProvider 
    .when('/food', {
        templateUrl: '../templates/products.html',
        controller: 'productsController',
        controllerAs: 'productsCtrl'
    })
    .when('/food/:id', {
        templateUrl: '../templates/productDetails.html',
        controller: 'productDetailsController',
        controllerAs: 'productDetailsCtrl'
    })
    .when('/', {
        redirectTo: '/food'
    });
}]);