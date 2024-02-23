var app = angular.module('myApp', []);
app.controller('UserController', function ($scope, $http, $filter, $window) {

    var host = window.location.protocol + "//" + window.location.host;
    var base_url = host + '/';
    $scope.frmUser = {

        Id_Number: null,
        Name: null,
        Firstname: null,
        LastName: null,
        Birth_Date: null,
        Gender: null,
        Id_Rol: null,
        Identification_Type_ID:null,
        Id_State: null,
        Id_Province: null,
        Id_Counties: null,
        Id_Cities: null,
        Email: null,
        Phone: null,

    }
    $scope.vSelectProvinces = [];
    $scope.vSelectCounties = [];
    $scope.vSelectCities = [];
    $scope.vSelectIdentificationType = [];
    $scope.vSelectUserState = [];
    $scope.vSelectRoles = [];
    $scope.loadData = function () {
        $(".loader").fadeIn();
       

        $(".loader").fadeOut();
    }
    $scope.loadData();
    $scope.GetProvince = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetProvinces/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                $scope.vSelectProvinces = response.data;
            }
        );
    }

    $scope.GetCounties = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetCounties/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                $scope.vSelectCounties = response.data;
            }
            );
    }

    $scope.GetCities = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetCities/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                $scope.vSelectCities = response.data;
            }
            );
    }

    $scope.GetIdentificationType = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetIdentificationType/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                $scope.vSelectIdentificationType = response.data;
            }
            );
    }

    $scope.GetUserStates = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetUserSates/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                $scope.vSelectUserState = response.data;
            }
            );
    }

    $scope.GetRoles = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetRoles/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                $scope.vSelectRoles = response.data;
            }
            );
    }
    
    $scope.OpenModal = function () {
        $('#modalUsers').modal('show');
    }

    $scope.GetProvince();
    $scope.GetCounties();
    $scope.GetCities();
    $scope.GetIdentificationType();
    $scope.GetUserStates();
    $scope.GetRoles();

    $scope.uploadStudent = function () {
        var userData = $scope.frmUser;
        $(".loader").fadeIn();

        $http({
            url: base_url + 'Administrator/UploadUser/',
            method: "POST",
            data: userData,
            responseType: 'json',

        })
            .then(function (response) {
                $(".loader").fadeOut();
                alert(response);
                $('#modalUsers').modal('show');
                window.location.reload()
               

            },
                function (response) {
                    alert(response);
                });
    }
});