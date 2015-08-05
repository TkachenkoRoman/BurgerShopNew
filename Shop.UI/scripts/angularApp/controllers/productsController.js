angular.module('burgerShop')
    .controller('productsController', ['$http', function ($http) {
    if (!this.tab)
        this.tab = 1; //default

    var shop = this;
    shop.products = [];

    this.showProductDetails = function (id) {
        var url = 'http://localhost:8080/api/products/' + id;
        $http.get(url).success(function (data) {
            //console.log('success');
            shop.product = data;
            $('#modal').css('display', 'block');
            $('.modal-bg').fadeIn();
        });
    };
    
    $('#close').click(function () { //close details popup 
        $('.modal-bg').fadeOut();
        $('#modal').fadeOut();
        return false;
    });

    this.selectTab = function (currTab) {
        this.tab = currTab;
        var filteredProducts = filterByCategory(shop.products, currTab);
        shop.chunkedProducts = chunk(filteredProducts, 3);
    };

    this.isSelected = function (tab) {
        return this.tab === tab;
    };

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

