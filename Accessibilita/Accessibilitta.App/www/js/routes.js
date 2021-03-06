angular.module('app.routes', [])

.config(function ($stateProvider, $urlRouterProvider, $httpProvider) {

    // Ionic uses AngularUI Router which uses the concept of states
    // Learn more here: https://github.com/angular-ui/ui-router
    // Set up the various states which the app can be in.
    // Each state's controller can be found in controllers.js
    $stateProvider

        .state('menu', {
            url: '/menu',
            abstract: true,
            templateUrl: 'templates/menu.html',
            controller: 'mainMenuCtrl'
        })

        .state('menu.busca', {
            url: '/busca',
            views: {
                'menu': {
                    templateUrl: 'templates/menu-busca.html',
                    controller: 'buscaCtrl'
                }
            }
        })

        .state('menu.chekin', {
            url: '/checkin',
            views: {
                'menu': {
                    templateUrl: 'templates/menu-checkin.html',
                    controller: 'checkinCtrl'
                }
            }
        })
        .state('menu.historico', {
            url: '/historico',
            views: {
                'menu': {
                    templateUrl: 'templates/menu-historico.html',
                    controller: 'historicoCtrl'
                }
            }
        })

        .state('menu.dashboard', {
            url: '/dashboard',
            views: {
                'menu': {
                    templateUrl: 'templates/menu-dashboard.html',
                    controller: 'dashboardCtrl'
                }
            }
        })


        .state('menu.perfil', {
            url: '/perfil',
            views: {
                'menu': {
                    templateUrl: 'templates/menu-perfil.html',
                    controller: 'perfilCtrl'
                }
            }
        })

        .state('registrar', {
            url: '/signup',
            templateUrl: 'templates/registrar.html',
            controller: 'registrarCtrl'
        })

        .state('login', {
            url: '/login',
            templateUrl: 'templates/login.html',
            controller: 'loginCtrl'
        })


        .state('avaliacao', {
            url: '/avaliacao/:place',
            templateUrl: 'templates/avaliacao.html',
            controller: 'avaliacaoCtrl'
        })


    ;
    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/login');

    //Interceptor
    $httpProvider.interceptors.push('APIInterceptor');

});