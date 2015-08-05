angular.module('burgerShop')
    .directive('setEqualHeightOfThumbnails', function () {
    return function(scope, element, attrs) {
        if (scope.$last){
            // iteration is complete, do whatever post-processing
            // is necessary
            equalHeight($(".thumbnail"));
        }
    };
});

function equalHeight(group) {
    var tallest = 0;
    group.each(function () {
        var thisHeight = $(this).height();
        if (thisHeight > tallest) {
            tallest = thisHeight;
        }
    });
    group.each(function () { $(this).height(tallest); });
}