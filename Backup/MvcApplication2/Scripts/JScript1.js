
/// <reference path="knockout-2.3.0.debug.js" />
/// <reference path="jquery-2.1.0.js" />
var zg = zg || {};
zg.cancion = function () {
    this.id = ko.observable();
    this.nombre = ko.observable();
    this.tipo = ko.observable();
    this.ultimaVez = ko.observable();
    
    this.cls = ko.computed(function() {
        if (this.tipo() !== undefined)
            return this.tipo().toLowerCase();
        return this.tipo();
    },this);
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


//zg.LoadData=function () {
    // on this click event, we popular the observable array
  
//};

zg.viewModel = function () {
    var cancionesSeleccionadas = ko.observableArray([]),
        //canciones = ko.observableArray(zg.demoData()),
        canciones = ko.observableArray([]),
        orden     = ko.observable(true);
        ordenDate = ko.observable(true);
        add       = function(elem) {
            if (cancionesSeleccionadas.indexOf(elem) < 0)
                cancionesSeleccionadas.push(elem);
        },
        up        = function(elem) {
            cancionesSeleccionadas.move(cancionesSeleccionadas.indexOf(elem), -1);
        },
        down      = function(elem) {
            cancionesSeleccionadas.move(cancionesSeleccionadas.indexOf(elem), 1);
        },
        remove    = function(elem) {
            cancionesSeleccionadas.remove(elem);
        },
        load      = function() {
            $.ajax({
                url: '/Home/Model/',
                type: "GET",
                dataType: 'json',
                success: function(data) {
                    canciones.removeAll();
                    canciones(AjaxResult(data));
                    canciones.valueHasMutated();
                    Size();
                }
            });
        },
        loadList      = function(id) {
            $.ajax({
                url: '/Home/List/' + id,
                type: "GET",
                dataType: 'json',
                success: function(data) {
                    debugger;
                    canciones.removeAll();
                    canciones(AjaxResult(data));
                    canciones.valueHasMutated();
                    Size();
                }
            });
        },
        sortCancion = function() {
            if (orden()) {
                orden(false);
                canciones(canciones().sort(CompareNameDesc));
            } else {
                canciones(canciones().sort(CompareNameAsc));
                orden(true);
            }
        },
        sortFecha = function() {
            if (ordenDate()) {
                ordenDate(false);
                canciones(canciones().sort(CompareDateDesc));
            } else {
                canciones(canciones().sort(CompareDateAsc));
                ordenDate(true);
            }
        },
        saveCanciones= function() {
            $.ajax({
                url: '/Home/SaveModel/',
                type: "POST",
                data: ko.toJSON(cancionesSeleccionadas)
            }).success(function(res) {
                    alert(res.Message);
            });
        };
    return {
        canciones: canciones,
        cancionesSeleccionadas: cancionesSeleccionadas,
        add: add,
        remove: remove,
        up:up,
        down:down,
        load:load,
        loadList:loadList,
        sortCancion:sortCancion,
        sortFecha:sortFecha,
        saveCanciones:saveCanciones
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
    return true;
};

ko.bindingHandlers.date = {
    update: function(element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());
        var textContent = moment(valueUnwrapped).format("YYYY-MM-DD");
        ko.bindingHandlers.text.update(element, function() { return textContent; });
    }
};