angular.module('burgerShop')
    .controller('productDetailsController', ['$http', '$routeParams', function ($http, $routeParams) {
        var shop = this;
        var url = 'http://localhost:8080/api/products/' + $routeParams.id;

        $http.get(url).success(function (data) {
            //console.log('success');
            shop.product = data;
        });
    }]);