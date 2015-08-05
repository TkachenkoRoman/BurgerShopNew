angular.module('burgerShop').directive('showOnHoverParent',
   function () {
       return {
           link: function (scope, element, attrs) {
               element.parent().bind('mouseenter', function () {
                   element.slideDown(150);
               });
               element.parent().bind('mouseleave', function () {
                   element.slideUp(150);
               });
           }
       };
   });