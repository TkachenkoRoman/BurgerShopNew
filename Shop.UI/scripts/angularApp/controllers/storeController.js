angular.module('burgerShop')
    .controller('storeController', ['$http', '$scope', 'StoreService', 'DataService', function ($http, $scope, StoreService, DataService) {

    var store = this;
    if (!store.tab)
        store.tab = 1; //default

    $scope.cart = StoreService.cart;
    DataService.products().then(function (response) {
        $scope.products = response.data;
        $scope.selectTab(store.tab);
    });
    

    $scope.showProductDetails = function (id) {
        for (var i = 0; i < $scope.products.length; i++)
        {
            if ($scope.products[i].Id == id)
            {
                $scope.productDetail = $scope.products[i];
            }
        }
        $('#modal').css('display', 'block');
        $('.modal-bg').fadeIn();
    };
    
    $('#close').click(function () { //close details popup 
        $('.modal-bg').fadeOut();
        $('#modal').fadeOut();
        return false;
    });

    $scope.selectTab = function (currTab) {
        store.tab = currTab;
        var filteredProducts = filterByCategory($scope.products, currTab);
        $scope.chunkedProducts = chunk(filteredProducts, 3);
    };

    $scope.isSelected = function (tab) {
        return store.tab === tab;
    };
}]);

function filterByCategory(products, categoryID) {
    var result = [];
    //products.forEach(function (product) {
    //    if (product.CategoryID == categoryID)
    //        result.push(product);
    //});
    for (var i = 0; i < products.length; i++)
    {
        if (products[i].CategoryID == categoryID)
            result.push(products[i]);
    }
    return result;
};

function chunk(arr, size) {
    var newArr = [];
    for (var i = 0; i < arr.length; i += size) {
        newArr.push(arr.slice(i, i + size));
    }
    return newArr;
};

