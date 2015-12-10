angular.module('app.services', [])

.factory('ApiEndpoint', function () {
    var serviceBase = 'http://localhost:2598';
    return {
        sign: serviceBase + '/Sign'

    }
})

.service('AccountService', function ($http, $httpParamSerializer, ApiEndpoint) {
    this.login = function (data, success, error) {
        if (!data.grant_type)
            data.grant_type = 'password';
        $http.post(ApiEndpoint.sign, $httpParamSerializer(data), { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }).success(success).error(error);
    }
})
.service('RateService', function () {

})