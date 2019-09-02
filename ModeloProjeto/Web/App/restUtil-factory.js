(() => {

    function customError(status) {
        throw {
            name: 'CustomError',
            message: 'Falha ao conectar no servidor: ' + status
        };
    };

    app.factory('restUtil', ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
        return {
            post: function (url, params) {
                $rootScope.searching = true;
                var dados = $http.post(url, params, null).success(function (data, status, headers, config) {
                    return data, status, headers, config;
                }).error(function (data, status, headers, config) {
                    return data, status, headers, config;
                });
                $rootScope.searching = false;
                return dados;
            },

            get: function (url) {
                $rootScope.searching = true;
                var dados = $http.get(url).success(function (data, status, headers, config) {
                    return data;
                }).error(function (data, status, headers, config) {
                    //  throw new CustomError(status);
                });
                $rootScope.searching = false;
                return dados;
            },
            getAsync: function (url) {
                var deferred = $q.defer();
                $http.get(url).success(function (data, status, headers, config) {
                        deferred.resolve(data, status, headers, config);
                    })
                    .error(function (data, status, headers, config) {
                        deferred.reject(data, status, headers, config);
                    });

                return deferred.promise;
            },
            getWithParams: function (url, args) {

                var config = {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                    },
                    params: {
                        object: args
                    }
                };
                var dados = $http.get(url, config).success(function (data, status, headers, config) {
                    return data;
                }).error(function (data, status, headers, config) {
                    customError(status);
                });

                return dados;
            },
            put: (url, data) => $http.put(url, data)
        };
    }]);

})();