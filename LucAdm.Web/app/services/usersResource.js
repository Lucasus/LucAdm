(function ()
{
    "use strict";

    angular.module("lucAdm").factory("usersResource", function ($resource)
    {
        var urlPrefix = "/api/users/";

        return $resource(urlPrefix,
        {
            id: "@id"
        }, 
        {
            'query': { method: "GET", isArray: false },
            'create': { method: "POST" },
            'update': { method: "POST", url: urlPrefix + ":id" },
            'delete': { method: "DELETE", url: urlPrefix + ":id" }
        });
    });
}());
