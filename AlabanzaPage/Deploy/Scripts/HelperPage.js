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

var cancionResult = function (data) {
    var item = data;
    var n = new zg.cancion();
    n.nombre(item.Nombre);
    n.tipo(item.Tipo);
    n.ultimaVez(item.UltimaVez);
    n.letra(item.Letra);
    n.id(item.Id);
    return n;
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
            //data: { dataSave: data },
            data:  data ,
            dataType: 'json',
            success: callback
        });
    }
};


var transposeProcess = function (list,amount)
{
    _.forEach(list, function (item) {
        var j = transposeChord(item.innerHTML, amount);
        item.textContent = j;
    });
}
var transposeChord = function (chord, amount) {
    var scale = ["C", "Cb", "C#", "D", "Db", "D#", "E", "Eb", "E#", "F", "Fb", "F#", "G", "Gb", "G#",
          "A", "Ab", "A#", "B", "Bb", "B#"];
    var transp = ["Cb", "C", "C#", "Bb", "Cb", "C", "C", "C#", "D", "Db", "D", "D#", "C", "Db", "D",
                  "D", "D#", "E", "Eb", "E", "F", "D", "Eb", "E", "E", "E#", "F#", "E", "F", "F#",
                  "Eb", "Fb", "F", "F", "F#", "G", "Gb", "G", "G#", "F", "Gb", "G", "G", "G#", "A",
                  "Ab", "A", "A#", "G", "Ab", "A", "A", "A#", "B", "Bb", "B", "C", "A", "Bb", "B",
                  "B", "B#", "C#"];
    var subst = chord.match(/[^b#][#b]?/g);
    for (var ax in subst) {
        if (scale.indexOf(subst[ax]) !== -1) {
            if (amount > 0) {
                for (ix = 0; ix < amount; ix++) {
                    var pos = scale.indexOf(subst[ax]);
                    var transpos = 3 * pos - 2 + 3;
                    subst[ax] = transp[transpos + 1];
                }
            }
            if (amount < 0) {
                for (ix = 0; ix > amount; ix--) {
                    var pos = scale.indexOf(subst[ax]);
                    var transpos = 3 * pos - 2 + 3;
                    subst[ax] = transp[transpos - 1];
                }
            }
        }
    }
    //chord = subst.join("");
    return subst.join("");
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

ko.bindingHandlers.date = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());
        var textContent = moment(valueUnwrapped).format("YYYY-MM-DD");
        ko.bindingHandlers.text.update(element, function () { return textContent; });
    }
};

ko.bindingHandlers.dateString = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor(), allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var pattern = allBindings.datePattern || 'YYYY-MM-DD';
        $(element).text(valueUnwrapped.toString(pattern));
    }
}

ko.observableArray.fn.sortByProperty = function (prop) {
    this.sort(function (obj1, obj2) {
        if (obj1[prop] === obj2[prop])
            return 0;
        else if (obj1[prop] < obj2[prop])
            return -1;
        else
            return 1;
    });
}



//ko.utils.stringStartsWith = function (string, startsWith) {
//    string = string || "";
//    if (startsWith.length > string.length)
//        return false;
//    return string.substring(0, startsWith.length) === startsWith;
//};
        