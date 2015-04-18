(function () {
    "use strict";

    angular.module('lucAdm').controller("UsersCtrl", function ($scope, $http, $modal) {

        // http://stackoverflow.com/questions/17838708/implementing-loading-spinner-using-httpinterceptor-and-angularjs-1-1-5
        $http.get("api/user").success(function (data) {
            var model = {
                list: data,
                totalPages: 3,
                total: 25,
                page: 1
            };

            $scope.users = model;

            $scope.addUser = function (userName) {
                model.list.push({ userName: userName, active: false });
            };

            $scope.pageChanged = function () {

            };

            $scope.openModal = function () {

                var modalInstance = $modal.open({
                    templateUrl: '/app/views/userModal.html',
                    controller: 'UserModalCtrl',
                    resolve: {
                        userId: function () { return id; }
                    }
                });

                //modalInstance.result.then(function () {
                //    loadKeywords($scope.keywordsList);
                //});
            };
        });
    });
}());