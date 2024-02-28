﻿var app = angular.module('myApp', []);
app.controller('AuthenticationController', function ($scope, $http, $filter, $window) {
    
    var host = window.location.protocol + "//" + window.location.host;
    var base_url = host + '/';
    $scope.firstName = "John";
    $scope.lastName = "Doe";
    $scope.loadData = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Home/GetRoles/',
            method: "POST",
            responseType: 'json',

        })
            .then(function (response) {
                alert("Perroooossss");
            }
            );
    }

    $scope.ValidateLogin = function () {
        //$http({
        //    dataType: 'text',
        //    url: base_url + 'Home/GetRoles/',
        //    method: "POST",
        //    responseType: 'json',

        //})
        //    .then(function (response) {
               
        //    }
        //);
        window.location.href = "/Coach/GymMachines";
    }

    $scope.OpenModal = function () {
        alert("Hi");
        $('#modalUsers').modal('show');
    }
    
   
});