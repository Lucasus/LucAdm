(function ()
{
    "use strict";

    angular.module('lucAdm').factory('usersResource', function ($resource, $q)
    {
        var urlPrefix = "/api/user/";

        return $resource(urlPrefix,
        {
            id: '@id'
        }, 
        {
            'query': { method: 'GET', isArray: false },
            'create': { method: 'POST' },
            'update': { method: 'POST', url: urlPrefix + ':id' },
            'delete': { method: 'DELETE', url: urlPrefix + ':id' }
        });
    });
}());
