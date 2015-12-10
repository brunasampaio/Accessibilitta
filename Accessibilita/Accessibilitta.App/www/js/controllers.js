angular.module('app.controllers', [])

.controller('registrarCtrl', function ($scope) {

})

.controller('loginCtrl', function ($scope, $state, $location, $localstorage, $ionicHistory, AccountService) {
    $scope.loginData = {
        userName: '',
        password: ''
    };

    $scope.doLogin = function () {
        var onSuccess = function (res) {
            if (res.access_token) {
                $ionicHistory.nextViewOptions({ disableBack: true });
                res.token_type = res.token_type.toUpperCase();
                $localstorage.setObject('token', res);                
                $state.go('menu.dashboard');
            }
        }
        var onError = function (res) {
            console.log(res);
        }
        AccountService.login(this.loginData, onSuccess, onError);
    }
})

.controller('buscarLocalCtrl', function ($scope) {

})

.controller('perfilCtrl', function ($scope) {

})

.controller('avaliacaoCtrl', function ($scope) {

})

.controller('dashboardCtrl', function ($scope) {

})
