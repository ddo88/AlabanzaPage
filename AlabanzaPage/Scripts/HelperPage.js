/// <reference path="underscore.js" />

var cancionesListResult = function (result) {

    var a = result;
    var list = ([]);
    if (result === null || result === undefined)
        return list;
    _.each(a, function (item) {
        var n = new zg.cancion();
        n.nombre   (item.Nombre);
        n.tipo     (item.Tipo);
        n.ultimaVez(item.UltimaVez);
        n.letra    (item.Letra);
        n.id(item.Id);

        list.push(n);
    });    
    return list;
};

var send = function (url, type, data, callback) {
    if (data === undefined) {
        $.ajax({
            url: url,
            type: type,
            dataType: 'json',
            success: callback
        });
    }
    else {
        $.ajax({
            url: url,
            type: type,
            data: data,
            dataType: 'json',
            success: callback
        });
    }
};

ko.observableArray.fn.move = function (index, delta) {

    // This method moves an element within the array
    // index = the array item you want to move
    // delta = the direction and number of spaces to move the item.
    //
    // For example:
    // move_element(myarray, 5, -1); // move up one space
    // move_element(myarray, 2, 1); // move down one space
    //
    // Returns true for success, false for error.

    var index2, item;

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

    item = this()[index2];
    this()[index2] = this()[index];
    this()[index] = item;
    this.valueHasMutated();
    return true;
};
