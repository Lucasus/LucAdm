﻿(function ()
{
    "use strict";

    angular.module("lucAdm").directive("ngConfirmClick", function ()
    {
        return {
            restrict: "A",
            link: function (scope, element, attrs)
            {
                element.bind("click", function ()
                {
                    var message = attrs.ngConfirmMessage;
                    if (message && confirm(message))
                    {
                        scope.$apply(attrs.ngConfirmClick);
                    }
                });
            }
        }
    });
}());
