/// <reference path="knockout-2.3.0.debug.js" />
/// <reference path="jquery-2.1.0.js" />
var zg = zg || {};
zg.cancion = function () {
    this.nombre = ko.observable();
    this.tipo = ko.observable();
    this.ultimaVez = ko.observable();
};
//como voy a cargar los datos????
zg.demoData = function () {
    list = [];
    for (var i = 1; i < 10; i++) {
        var a = new zg.cancion();
        a.nombre(i);
        a.tipo("adoracion");
        a.ultimaVez(new Date());
        list.push(a);
    }
    return list;
};



zg.viewModel = function () {
    var cancionesSeleccionadas = ko.observableArray([]),
        canciones = ko.observableArray(zg.demoData()),
        add = function (elem) {
            cancionesSeleccionadas.push(elem);
        },
        up = function (elem) {
          cancionesSeleccionadas.move(cancionesSeleccionadas.indexOf(elem), -1);  
        },
        down = function (elem) {
           cancionesSeleccionadas.move(cancionesSeleccionadas.indexOf(elem), 1);
        },
        remove = function (elem) {
            cancionesSeleccionadas.remove(elem);
        };
    return {
        canciones: canciones,
        cancionesSeleccionadas: cancionesSeleccionadas,
        add: add,
        remove: remove,
        up:up,
        down:down
    };
};

ko.observableArray.fn.move = function ( index, delta) {

    // This method moves an element within the array
    // index = the array item you want to move
    // delta = the direction and number of spaces to move the item.
    //
    // For example:
    // move_element(myarray, 5, -1); // move up one space
    // move_element(myarray, 2, 1); // move down one space
    //
    // Returns true for success, false for error.

    var index2,item;

    // Make sure the index is within the array bounds
    if (index < 0 || index >= this().length) {
        return false;
    }

    // Make sure the target index is within the array bounds
    index2 = index + delta;
    if (index2 < 0 || index2 >= this().length || index2 == index) {
        return false;
    }

    // Move the elements in the array
    
        item           = this()[index2];
        this()[index2] = this()[index];
        this()[index]  = item;
        this.valueHasMutated();   
    return true;;
};