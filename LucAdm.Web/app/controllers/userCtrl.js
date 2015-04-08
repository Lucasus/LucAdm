(function () {
    "use strict";

    angular.module('lucAdm').controller("UserCtrl", function ($scope, $http) {

        $http.get("api/user").success(function (data) {
            var model = {
                list: data,
                totalPages: 3,
                total: 25,
                page: 1,
            };

            $scope.users = model;

            $scope.addUser = function (userName) {
                model.list.push({ userName: userName, active: false });
            };

            $scope.pageChanged = function () {

            };
        });
    });
}());