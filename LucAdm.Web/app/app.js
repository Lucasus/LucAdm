var app;

(function () {
    "use strict";

    app = angular.module('lucAdm', ['ui.bootstrap']);

}());

var model = {
    list: [{ name: "Gandalf", active: "Yes"},
        { name: "Legolas", active: "No" },
        { name: "Gimli", active: "No" },
        { name: "Frodo", active: "Yes" }]
};