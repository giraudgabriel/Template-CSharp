app.config(function ($locationProvider, $routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "home/home.html",
            controller: "homeCtrl",
            parent: 'menu'
        })
        .otherwise({
            redirectTo: '/'
        });
});