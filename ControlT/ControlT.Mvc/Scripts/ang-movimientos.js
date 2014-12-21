(function () {
    var app = angular.module('controlT', []);

    app.controller('MovimientosController', function () {
        this.items = new [];
    }); 

    var gem = {
        name: 'Azurite',
        price: 110.50,
        canPurchase: false,
        soldOut: true
    };
})()
