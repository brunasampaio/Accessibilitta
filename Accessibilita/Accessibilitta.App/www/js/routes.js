angular.module('app.routes', [])

.config(function($stateProvider, $urlRouterProvider) {

  // Ionic uses AngularUI Router which uses the concept of states
  // Learn more here: https://github.com/angular-ui/ui-router
  // Set up the various states which the app can be in.
  // Each state's controller can be found in controllers.js
  $stateProvider
    
      
        
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
        
      
    
      
        
    .state('menu.buscarLocal', {
      url: '/search-place',
      views: {
        'side-menu21': {
          templateUrl: 'templates/buscarLocal.html',
          controller: 'buscarLocalCtrl'
        }
      }
    })
        
      
    
      
    .state('menu', {
      url: '/side-menu21',
      abstract:true,
      templateUrl: 'templates/menu.html'
    })
      
    
      
        
    .state('menu.perfil', {
      url: '/profile',
      views: {
        'side-menu21': {
          templateUrl: 'templates/perfil.html',
          controller: 'perfilCtrl'
        }
      }
    })
        
      
    
      
        
    .state('avaliacao', {
      url: '/rating-place',
      templateUrl: 'templates/avaliacao.html',
      controller: 'avaliacaoCtrl'
    })
        
      
    ;

  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/login');

});