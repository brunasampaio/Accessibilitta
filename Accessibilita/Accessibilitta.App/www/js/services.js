angular.module('app.services', [])

.factory('ApiEndpoint', function () {
    var root = 'http://localhost:2598';
    var baseUrlApi = root + '/api';
    return {
        account: {
            sign: root + '/Sign',
            update: baseUrlApi + '/Account/Update',
            register: baseUrlApi + '/Account/Register',
            info: baseUrlApi + '/Account/GetInfo'
        },
        place: {
            getTopAvailabilited: baseUrlApi + '/Place/GetTopAvailabilited',
            getRatedPlaceByAccount: baseUrlApi + '/Place/GetRatedPlaceByAccount',
            searchPlace: baseUrlApi + '/Place/SearchPlace'
        },
        rateType: {
            getAll: baseUrlApi + '/RateType/GetAll'
        },
        rate: {
            ratePlace: baseUrlApi + '/Rate/RatePlace'
        }

    }
})

.factory('APIInterceptor', function ($localstorage, ApiEndpoint) {
    var interceptor = {
        request: function (config) {
            var objToken = $localstorage.getObject('token');
            if (objToken && config.url != ApiEndpoint.account.sign) {
                config.headers.Authorization = objToken.token_type + " " + objToken.access_token;
            }
            return config;
        },
        response: function (response) {
            return response;
        }
    };
    return interceptor;
})

.service('AccountService', function ($http, $httpParamSerializer, ApiEndpoint) {
    this.login = function (data, success, error) {
        if (!data.grant_type)
            data.grant_type = 'password';
        $http.post(ApiEndpoint.account.sign, $httpParamSerializer(data), { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }).success(success).error(error);
    }

    this.update = function (data, success, error) {
        $http.post(ApiEndpoint.account.update, data).success(success).error(error);
    }

    this.register = function (data, success, error) {
        $http.post(ApiEndpoint.account.register, data).success(success).error(error);
    }

    this.getInfo = function (success, error) {
        $http.get(ApiEndpoint.account.info).success(success).error(error);
    }
})
.service('PlaceService', function ($http, ApiEndpoint) {
    this.getTopAvailabilited = function (limit, success, error) {
        $http.get(ApiEndpoint.place.getTopAvailabilited, { params: { limit: limit } }).success(success).error(error);
    }

    this.searchPlace = function (data, success, error) {
        $http.get(ApiEndpoint.place.searchPlace, { params: data }).success(success).error(error);
    }

    this.getRatedPlaceByAccount = function (success, error) {
        $http.get(ApiEndpoint.place.getRatedPlaceByAccount).success(success).error(error);
    }
})
.service('RateService', function ($http, $httpParamSerializer, ApiEndpoint) {
    this.ratePlace = function (data, success, error) {
        $http.post(ApiEndpoint.rate.ratePlace, data).success(success).error(error);
    }
})
.service('RateTypeService', function ($http, ApiEndpoint) {
    this.getRateTypes = function (success, error) {
        $http.get(ApiEndpoint.rateType.getAll).success(success).error(error);
    }
})