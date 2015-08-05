angular.module('burgerShop', ['ngRoute']).config(['$routeProvider', function ($routeProvider) {
    $routeProvider 
    .when('/food', {
        templateUrl: '../templates/products.html',
        controller: 'productsController',
        controllerAs: 'productsCtrl'
    })
    .when('/', {
        redirectTo: '/food'
    });
}]);