(function () {
    'use strict';

    angular
        .module('app')
        .controller('CoachController', CoachController);

    CoachController.$inject = ['$location'];

    function CoachController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'CoachController';

        activate();

        function activate() { }
    }

    $scope.OpenModal = function () {
        $('#ModalRoutines').modal('show');
    }

    $scope.GetProvince();
    
})();
