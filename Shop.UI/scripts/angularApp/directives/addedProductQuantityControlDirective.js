angular.module('burgerShop').directive('addedProductQuantityControl',
   function () {
       return {
           link: function (scope, element, attrs) {
               var control = this;
               control.check = function (element, id) {
                   var productId = id;
                   for (var i = 0; i < scope.cart.items.length; i++) {
                       if (scope.cart.items[i].id == productId) {
                           element.removeClass('glyphicon glyphicon-plus');
                           element.addClass('glyphicon glyphicon-ok-sign');
                       }
                   }
               };
               element.parent().bind('mouseenter mouseleave', function () {
                   control.check(element, attrs.addedProductQuantityControl);
               });
               element.bind('click', function () {
                   control.check(element, attrs.addedProductQuantityControl);
               });
           }
       };
   });