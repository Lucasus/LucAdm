(function () {
    "use strict";

    angular.module("lucAdm").controller("UserModalCtrl", function ($scope, $modalInstance, usersResource, userId) {

        function init() {
            $scope.user = {};

            if (userId) {
                usersResource.get({ id: userId }, function (data) {
                    $scope.user = data;
                });
            }

            $scope.cancel = function () {
                $modalInstance.dismiss("cancel");
            };

            $scope.save = function (user) {
                if (userId) {
                    usersResource.update({ id: userId }, user, function () {
                        $modalInstance.close();
                    });
                }
                else {
                    usersResource.create({}, user, function () {
                        $modalInstance.close();
                    });
                }
            }
        }

        init();
    });
}());
