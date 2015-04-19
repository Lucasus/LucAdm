(function () {
    "use strict";

    angular.module("lucAdm").controller("UsersCtrl", function ($scope, $modal, usersResource) {

        var users = {
            searchTerm: "",
            sortColumn: "",
            sortType: "",
            page: 1,
            pageSize: 10,
            list: null,
            total: null
        };

        $scope.users = users;

        function loadUsers() {
            usersResource.query({
                searchTerm: users.searchTerm,
                sortColumn: users.sortColumn,
                sortType: users.sortType,
                page: users.page,
                pageSize: users.pageSize
            }, function (result) {
                users.list = result.list;
                users.total = result.total;
            });
        }

        loadUsers();

        $scope.pageChanged = function () {
            loadUsers();
        };

        $scope.delete = function (id) {
            usersResource.delete({ id: id }, function () {
                loadUsers();
            });
        };

        $scope.search = function () {
            loadUsers();
        };

        $scope.sort = function (column) {
            users.sortColumn = column;
            users.sortType = (users.sortType === "asc" ? "desc" : "asc");
            loadUsers();
        };

        $scope.openModal = function (id) {

            var modalInstance = $modal.open({
                templateUrl: "/app/views/userModal.html",
                controller: "UserModalCtrl",
                resolve: {
                    userId: function () { return id; }
                }
            });

            modalInstance.result.then(function () {
                loadUsers();
            });
        };
    });
}());