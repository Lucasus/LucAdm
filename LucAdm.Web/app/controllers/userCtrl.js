(function () {
    "use strict";

    angular.module('lucAdm').controller("UserCtrl", function ($scope, $http) {

        $http.get("api/user").success(function (data) {
            var model = { list: data };
            $scope.users = model;

            $scope.addUser = function (userName) {
                model.list.push({ userName: userName, active: false });
            }
        });
    });
}());