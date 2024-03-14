var app = angular.module('myApp', []);
app.controller('AuthenticationController', function ($scope, $http, $filter, $window) {
    
    var host = window.location.protocol + "//" + window.location.host;
    var base_url = host + '/';
    $scope.frmUser = {

        IdNumber: null,
        Password:null

    }
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
        $(".spinner").fadeIn();
        var userData = $scope.frmUser;
        if ($scope.frmUser.IdNumber == null || $scope.frmUser.Password == null) {
            $(".spinner").fadeOut();
            Swal.fire('Debe completar el formulario');

        }
        else {
            $http({
                dataType: 'text',
                url: base_url + 'Login/ValidateLogin/',
                method: "POST",
                data: userData,
                responseType: 'json',

            })
                .then(function (response) {
                    $(".spinner").fadeOut();
                    if (response.data.res) {
                        if (response.data.rol == "Administrador") {
                            window.location.href = "/Home/_LayoutAdmin";
                        }
                        else {
                            if (response.data.rol == "Entrenador") {
                                window.location.href = "/Home/_LayoutCoach";
                            }
                            else {
                                window.location.href = "/Home/_LayoutUser";
                            }

                        }


                    }
                    else {
                        Swal.fire(response.data.message);

                    }

                }
                );
        }
        
        
        
    }

    $scope.OpenModal = function () {
        alert("Hi");
        $('#modalUsers').modal('show');
    }
    
   
});