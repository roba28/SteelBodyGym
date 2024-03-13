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
        IdRol: null,
        IdentificationTypeId:null,
        IdState: null,
        IdProvince: null,
        IdCounties: null,
        IdCities: null,
        Email: null,
        Phone: null,
    }
    $scope.vSelectProvinces = [];
    $scope.vSelectCounties = [];
    $scope.vSelectCities = [];
    $scope.vSelectIdentificationType = [];
    $scope.vSelectUserState = [];
    $scope.vSelectRoles = [];
    var dtTableUser;
    $scope.loadData = function () {
        $(".loader").fadeIn();
       

        $(".loader").fadeOut();
    }
    $scope.loadData();

    if ($.fn.dataTable.isDataTable('#dataTableUsers')) {
        dtTableUser = $('#dataTableUsers').DataTable();
    } else {
        dtTableUser = $('#dataTableUsers')
            .DataTable({
                buttons: true,
                scrollX: false,
                bFilter: false,
                bInfo: false,
                responsive: true,
                ordering: false,
                processing: true,
                iDisplayLength: 25,
                searching: false,
                deferLoading: 0,
                bLengthChange: false,
                serverSide: true,
                language: { "url": "https://cdn.datatables.net/plug-ins/1.10.13/i18n/Spanish.json" },
                "ajax": {
                    "url": base_url + "Administrator/GetUserData/",
                    "type": "POST",
                    "datatype": "json",
                    data: function (d) {
                        if (!$scope.frmUser.Id_Number) {
                            $scope.frmUser.Id_Number = "";
                        }
                        d.Accounts_Receivable_GUID = $scope.frmUser.Id_Number ? $scope.frmUser.Id_Number : "";
                    },
                    error: function () {
                        swal("Error!", "Error intente mas tarde!", "error");
                    },
                },
                columnDefs: [
                    { responsivePriority: 1, targets: 0 },
                    { responsivePriority: 2, targets: -1, className: "dt-font-size" },
                ],
                aoColumns: [
                    { "data": "idNumber" },
                    { "data": "name" },
                    { "data": "firstname" },
                    { "data": "lastName" },
                    { "data": "email" },
                    { "data": "phone" },
                    {
                        "className": 'details-control',
                        "orderable": false,
                        "data": null,
                        "render": function (data) {
                            
                                return '<button  class="btn btn-main">Actualizar</button>';
                            
                        },
                    },
                    {
                        "className": 'details-control',
                        "orderable": false,
                        "data": null,
                        "render": function (data) {

                            return '<button  class="btn btn-main">Eliminar</button>';

                        },
                    }
                ],

            });
    }
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
                if (response.data) {
                    $(".loader").fadeOut();
                    swal.fire({
                        title: "Éxito!",
                        text: "Cliente creado con éxito",
                        icon: "success"
                    });
                    $('#modalUsers').modal('hide');
                    dtTableUser.ajax.reload();
                } else {
                    $(".loader").fadeOut();
                    swal.fire({
                        icon: "error",
                        title: "Error",
                        text: "Ocurrio un error por favor intente mas tarde!"
                    });
                    $('#modalUsers').modal('hide');
                    dtTableUser.ajax.reload();
                }
                


            });
    }
});