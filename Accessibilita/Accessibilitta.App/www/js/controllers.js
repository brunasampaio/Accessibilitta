angular.module('app.controllers', [])

.controller('registrarCtrl', function ($scope, $ionicHistory, $ionicPopup, AccountService) {
    $scope.account = {};
    $scope.doRegister = function () {
        AccountService.register($scope.account, function (res) {
            if (res.hasError) {
                $ionicPopup.alert({
                    title: 'Erro',
                    template: res.errorMessage
                });
            }
            else {
                $ionicPopup.alert({
                    title: 'Registrar Conta',
                    template: 'Conta registrada com sucesso!'
                });
                $ionicHistory.goBack();
            }
        }, function (res) { console.log(res) })
    }
})

.controller('mainMenuCtrl', function ($scope, $state, $localstorage) {
    $scope.doLogout = function () {
        $localstorage.remove('token');
        $state.go('login')
    }
})

.controller('loginCtrl', function ($scope, $state, $location, $localstorage, $ionicPopup, AccountService) {
    $scope.loginData = {
        userName: '',
        password: ''
    };

    $scope.doLogin = function () {
        var onSuccess = function (res) {
            if (res.access_token) {
                res.token_type = res.token_type.toUpperCase();
                $localstorage.setObject('token', res);
                $state.go('menu.dashboard');
            }
        }
        var onError = function (res) {
            $ionicPopup.alert({
                title: 'Erro',
                template: res.error_description
            })
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

.controller('perfilCtrl', function ($scope, $state, $ionicPopup, AccountService) {
    $scope.account = {};
    $scope.doUpdateAccount = function () {
        AccountService.update($scope.account, function (res) {
            $ionicPopup.alert({
                title: 'Atualizar Dados',
                template: 'Dados atulizados com sucesso!'
            });
            $scope.getInfo();
        }, function (res) { console.log(res); })
    }
    $scope.getInfo = function () {
        AccountService.getInfo(function (res) {
            $scope.account = res.data;
        }, function (res) { console.log(res) });
    }
    $scope.getInfo();
})

.controller('avaliacaoCtrl', function ($scope, $state, $stateParams, RateTypeService, RateService) {
    $scope.place = JSON.parse($stateParams.place);
    $scope.rateTypes = [];
    RateTypeService.getRateTypes(function (res) {
        $scope.rateTypes = res.data;
    }, function (res) { console.log(res) });

    $scope.doRate = function () {
        var ratePlaceData = {
            placeId: this.place.placeID,
            rates: []
        };
        angular.forEach(this.rateTypes, function (rate) {
            ratePlaceData.rates.push({ RateTypeID: rate.rateTypeID, Rating: rate.rating })
        });
        RateService.ratePlace(ratePlaceData, function (res) {
            $state.go('menu.dashboard');
        }, function (res) { console.log(res) })
    }
})

.controller('dashboardCtrl', function ($scope, $state, PlaceService) {
    $scope.places = [];

    $scope.doListData = function () {
        PlaceService.getTopAvailabilited(20, function (res) {
            $scope.places = res.data;
            $scope.$broadcast('scroll.refreshComplete');
        }, function (res) { console.log(res); });
    }

    $scope.doListData();
})
