var app = angular.module('myApp', []);
app.controller('MedsController', function ($scope, $http, $filter, $window) {

    var host = window.location.protocol + "//" + window.location.host;
    var base_url = host + '/';
    $scope.frmRoutine = {
        RoutineNumber: null,
        RoutineName: null,
        MuscleType: null,
        Repetitions: null
    };

    $scope.addRoutine = function () {
        var routineData = $scope.frmRoutine;
        $(".loader").fadeIn();

        $http({
            url: base_url + 'Meds/AddRoutine/',
            method: "POST",
            data: routineData,
            responseType: 'json'
        })
            .then(function (response) {
                if (response.data) {
                    $(".loader").fadeOut();
                    swal.fire({
                        title: "Éxito!",
                        text: "Medida agregada con éxito",
                        icon: "success"
                    });
                    $('#ModalMeds').modal('hide');
                } else {
                    $(".loader").fadeOut();
                    swal.fire({
                        icon: "error",
                        title: "Error",
                        text: "Ocurrió un error. Por favor, inténtelo de nuevo más tarde."
                    });
                    $('#ModalMeds').modal('hide');
                }
            });
    };
    $scope.uploadStudent = function () {
        var routineData = {
            RoutineNumber: $scope.frmUser.RoutineNumber,
            RoutineName: $scope.frmUser.RoutineName,
            MuscleType: $scope.frmUser.MuscleType,
            Repetitions: $scope.frmUser.Repetitions
        };

        $(".loader").fadeIn();

        $http({
            url: base_url + 'Meds/AddRoutine/',
            method: "POST",
            data: routineData,
            responseType: 'json'
        })
            .then(function (response) {
                $(".loader").fadeOut();
                if (response.data) {
                    swal.fire({
                        title: "Éxito!",
                        text: "Rutina agregada con éxito",
                        icon: "success"
                    });
                    $('#ModalMeds').modal('hide');
                } else {
                    swal.fire({
                        icon: "error",
                        title: "Error",
                        text: "Ocurrió un error. Por favor, inténtelo de nuevo más tarde."
                    });
                    $('#ModalMeds').modal('hide');
                }
            })
            .catch(function (error) {
                console.error("Error al agregar la rutina:", error);
                $(".loader").fadeOut();
                swal.fire({
                    icon: "error",
                    title: "Error",
                    text: "Ocurrió un error. Por favor, inténtelo de nuevo más tarde."
                });
                $('#ModalMeds').modal('hide');
            });
    };

    $scope.GetProvince = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetProvinces/',
            method: "POST",
            responseType: 'json'
        })
            .then(function (response) {
                $scope.vSelectProvinces = response.data;
            });
    };

    $scope.GetCounties = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetCounties/',
            method: "POST",
            responseType: 'json'
        })
            .then(function (response) {
                $scope.vSelectCounties = response.data;
            });
    };

    $scope.GetCities = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetCities/',
            method: "POST",
            responseType: 'json'
        })
            .then(function (response) {
                $scope.vSelectCities = response.data;
            });
    };

    $scope.GetIdentificationType = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetIdentificationType/',
            method: "POST",
            responseType: 'json'
        })
            .then(function (response) {
                $scope.vSelectIdentificationType = response.data;
            });
    };

    $scope.GetUserStates = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetUserSates/',
            method: "POST",
            responseType: 'json'
        })
            .then(function (response) {
                $scope.vSelectUserState = response.data;
            });
    };

    $scope.GetRoles = function () {
        $http({
            dataType: 'text',
            url: base_url + 'Administrator/GetRoles/',
            method: "POST",
            responseType: 'json'
        })
            .then(function (response) {
                $scope.vSelectRoles = response.data;
            });
    };

    $scope.OpenModal = function () {
        $('#ModalMeds').modal('show');
    };

    $scope.GetProvince();
    $scope.GetCounties();
    $scope.GetCities();
    $scope.GetIdentificationType();
    $scope.GetUserStates();
    $scope.GetRoles();

});

