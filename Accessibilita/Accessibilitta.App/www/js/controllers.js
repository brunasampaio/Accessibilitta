angular.module('app.controllers', [])

.controller('registrarCtrl', function ($scope) {

})

.controller('mainMenuCtrl', function($scope, $state, $localstorage) {
    $scope.doLogout = function () {
        $localstorage.remove('token');
        $state.go('login')
    }
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

.controller('buscaCtrl', function ($scope, $state, PlaceService) {   

    $scope.doSearch = function () {
        var formData = this.formData;
        navigator.geolocation.getCurrentPosition(function (position) {
            formData.lat = position.coords.latitude;
            formData.lng = position.coords.longitude;

            PlaceService.searchPlace(formData, function (res) {
                $scope.places = res.data;
            }, function (res) { console.log(res); });
        });        
    }
})

.controller('perfilCtrl', function ($scope) {

})

.controller('avaliacaoCtrl', function ($scope) {

})

.controller('dashboardCtrl', function ($scope, $state, PlaceService) {
    $scope.places = [];

    PlaceService.getTopAvailabilited(20, function (res) {
        $scope.places = res.data;
    }, function (res) { console.log(res); });
})
