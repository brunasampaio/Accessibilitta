angular.module('app.controllers', [])

.controller('registrarCtrl', function ($scope) {

})

.controller('mainMenuCtrl', function ($scope, $state, $localstorage) {
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

.controller('buscaCtrl', function ($scope, $state, $ionicHistory, PlaceService) {

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

    $scope.openDetail = function (place) {
        $ionicHistory.nextViewOptions({ disableBack: false });
        $state.go('avaliacao');
    }
})

.controller('perfilCtrl', function ($scope, $state, RateTypeService) {
    $scope.rateTypes = [];
    RateTypeService.getRateTypes(function (res) {
        $scope.rateTypes = res.data;
    }, function (res) { console.log(res); })
})

.controller('avaliacaoCtrl', function ($scope, $state, RateTypeService) {
    $scope.rateTypes = [];
    RateTypeService.getRateTypes(function (res) {
        $scope.rateTypes = res.data;
    }, function (res) { console.log(res) });

    $scope.doRate = function () {
        var placeId = this.place.placeId;
        var ratePlaceData = {
            PlaceId: placeId,
            Rates: []
        };
        angular.forEach(this.rateTypes, function (rate) {
            ratePlaceData.Rates.push({ RateTypeId: rate.rateTypeId, Rating: rate.rating })
        });
        RateTypeService.ratePlace(ratePlaceData, function (res) {
            console.log('true');
        }, function(res) { console.log(res) })
    }
})

.controller('dashboardCtrl', function ($scope, $state, PlaceService) {
    $scope.places = [];

    PlaceService.getTopAvailabilited(20, function (res) {
        $scope.places = res.data;
    }, function (res) { console.log(res); });
})
