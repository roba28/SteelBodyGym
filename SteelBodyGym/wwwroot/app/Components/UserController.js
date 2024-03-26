var app = angular.module('myApp', []);
app.controller('UserController', function ($scope, $http, $filter, $window) {

    var host = window.location.protocol + "//" + window.location.host;
    var base_url = host + '/';
    $scope.frmUser = {

        IdNumber: null,
        Name: null,
        Firstname: null,
        LastName: null,
        BirthDate: null,
        Gender: null,
        IdRol: null,
        IdentificationTypeId:null,
        IdState: null,
        IdProvince: null,
        IdCounties: null,
        IdCities: null,
        Email: null,
        Phone: null
    }
    $scope.IsInsert= false;
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

    var element = document.getElementById("homeMenu");
    element.classList.remove("active");

    var element1 = document.getElementById("UserMenu");
    element1.classList.add("active");

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
                            
                            return '<button  class="btn btn-warning text-black">Actualizar</button>';
                            
                        },
                    },
                    {
                        "className": 'details-control',
                        "orderable": false,
                        "data": null,
                        "render": function (data) {

                            return '<button  class="btn btn-danger text-white">Eliminar</button>';

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
        $scope.frmUser.IdNumber = null;
        $scope.frmUser.Name = null;
        $scope.frmUser.Firstname = null;
        $scope.frmUser.LastName = null;
        $scope.frmUser.BirthDate = null;
        $scope.frmUser.Gender = null;
        $scope.frmUser.IdRol = null;
        $scope.frmUser.IdentificationTypeId = null;
        $scope.frmUser.IdState = null;
        $scope.frmUser.IdProvince = null;
        $scope.frmUser.IdCounties = null;
        $scope.frmUser.IdCities = null;
        $scope.frmUser.Email = null;
        $scope.frmUser.Phone = null;
        $('#modalUsers').modal('show');
    }

    $scope.OpenUpdateModal = function (vIDNumer) {
        $http({
            url: base_url + 'Administrator/GetUserInfoByIDNumber/',
            method: "POST",
            data: JSON.stringify(vIDNumer),
            responseType: 'json',

        })
            .then(function (response) {

                $scope.frmUser.IdNumber = response.data.idNumber;
                $scope.frmUser.Name = response.data.name;
                $scope.frmUser.Firstname = response.data.firstname;
                $scope.frmUser.LastName = response.data.lastName;
                $scope.frmUser.BirthDate = new Date(response.data.birthDate);
                $scope.frmUser.Gender = response.data.gender;
                $scope.frmUser.IdRol = response.data.idRol;
                $scope.frmUser.IdentificationTypeId = response.data.identificationTypeId;
                $scope.frmUser.IdState = response.data.idState;
                $scope.frmUser.IdProvince = response.data.idProvince;
                $scope.frmUser.IdCounties = response.data.idCounties;
                $scope.frmUser.IdCities = response.data.idCities;
                $scope.frmUser.Email = response.data.email;
                $scope.frmUser.Phone = response.data.phone;
                $('#modalUpdateUsers').modal('show');
            });


        
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
                url: base_url + 'Administrator/InsertUser/',
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
                            text: "El cliente ya existe en el sistema!"
                        });
                        $('#modalUsers').modal('hide');
                        dtTableUser.ajax.reload();
                    }



                });
    }

    $('#dataTableUsers').on('click', 'button', function () {
        var action = $(this).text();
        var vFila = dtTableUser.row($(this).parents('tr')).data();
        var vIDNumer = null;
        if (vFila == undefined) {
            var vSelected_row = $(this).parents('tr');
            if (vSelected_row.hasClass('child')) {
                vSelected_row = vSelected_row.prev();
            }
            var vRowData = $('#dataTableUsers').DataTable().row(vSelected_row).data();
            vIDNumer = vRowData.idNumber;
        }
        else {
            vIDNumer = vFila.idNumber;
        }
        if (action == "Eliminar") {
            $scope.DeleteClient(vIDNumer);
        }
        if (action == "Actualizar") {
            $scope.OpenUpdateModal(vIDNumer);
        }

    });

    $scope.DeleteClient = function (vIDNumber) 
    {
        Swal.fire({
            title: "Seguro que desea eliminar el cliente?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Si"
        }).then((result) => {
            if (result.isConfirmed) {

                $http({
                    url: base_url + 'Administrator/DeleteUser/',
                    method: "POST",
                    data: JSON.stringify(vIDNumber),
                    responseType: 'json',

                })
                    .then(function (response) {
                        if (response.data) {
                            $(".loader").fadeOut();
                            Swal.fire({
                                title: "Eliminado!",
                                text: "Cliente eliminado con éxito!",
                                icon: "success"
                            });
                            dtTableUser.ajax.reload();
                        } else {
                            $(".loader").fadeOut();
                            swal.fire({
                                icon: "error",
                                title: "Error",
                                text: "Ocurrio un error por favor intente mas tarde!"
                            });
                            dtTableUser.ajax.reload();
                        }
                    });
            }
        });

    }

    $scope.updateUser = function () {
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
                            text: "Cliente actualizado con éxito",
                            icon: "success"
                        });
                        $('#modalUpdateUsers').modal('hide');
                        dtTableUser.ajax.reload();
                    } else {
                        $(".loader").fadeOut();
                        swal.fire({
                            icon: "error",
                            title: "Error",
                            text: "Ocurrio un error por favor intente mas tarde!"
                        });
                        $('#modalUpdateUsers').modal('hide');
                        dtTableUser.ajax.reload();
                    }



                });

    }

});