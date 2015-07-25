angular.module('burgerShop')
    .controller('productsController', ['$http', function ($http) {
    this.tab = 1; //default

    this.selectTab = function (currTab) {
        this.tab = currTab;
        var filteredProducts = filterByCategory(shop.products, currTab);
        shop.chunkedProducts = chunk(filteredProducts, 3);
    };

    this.isSelected = function (tab) {
        return this.tab === tab;
    };

    var shop = this;
    shop.products = [];

    $http.get('http://localhost:8080/api/products').success(function (data) {
        //console.log('success');
        shop.products = data;
        var filteredProducts = filterByCategory(data, 1); // default
        shop.chunkedProducts = chunk(filteredProducts, 3);
    });

}]);

function filterByCategory(products, categoryID) {
    var result = [];
    products.forEach(function (product) {
        if (product.CategoryID == categoryID)
            result.push(product);
    });
    return result;
};

function chunk(arr, size) {
    var newArr = [];
    for (var i = 0; i < arr.length; i += size) {
        newArr.push(arr.slice(i, i + size));
    }
    return newArr;
};

