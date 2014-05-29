/// <reference path="../jquery-2.1.0.intellisense.js" />
/// <reference path="../knockout-2.2.0.js" />
/// <reference path="../underscore.js" />
/// <reference path="../KnockoutModel/cancion_model.js" />
/// <reference path="../HelperPage.js" />

var zg = zg || {};

zg.listaVM = function () {
    cancionS = new zg.cancion(),
    sugerenciaS = new zg.cancion(),
    lista = new zg.lista(),
    listado = ko.observableArray(),
    loadLista = function () {
        send('/Lista/Ultima', 'Get', undefined, function (data) {
            if (data === "") {
            }
            else {
                var i = 0;
                lista.id(data.Id);
                lista.idUsuario(data.IdUsuario);
                lista.fecha(data.Fecha);
                lista.canciones(cancionesListResult(data.Canciones));
                lista.sugerencias(cancionesListResult(data.Sugerencias));
                lista.final(data.Final);
                //lista.valueHasMutated();
            }
        });
    },
    loadCanciones = function () {
        send('/Cancion/Listado', 'Get', undefined, function (data) {
            listado.removeAll();
            listado(cancionesListResult(data));
            listado.valueHasMutated();
            if (lista.canciones().length > 0)
                selectSong(lista.canciones());
        });
    },
    selectSong = function (elm) {

        for (var i = 0; i < elm.length; i++) {
            for (var j = 0; j < listado().length; j++) {
                if (listado()[j].id() === elm[i].id())
                    listado()[j].selected(true);
            }
        }
        listado.valueHasMutated();
    },
    select = function (elm) {
        if (elm.selected() === false) {
            elm.selected(true);
            lista.canciones.push(elm);
        }
        else {
            elm.selected(false);
            lista.canciones.remove(elm);
        }
    },
    selectSuggest = function (elm) {
        if (elm.selected() === false) {
            elm.selected(true);
            lista.sugerencias.push(elm);
        }
        else {
            elm.selected(false);
            lista.sugerencias.remove(elm);
        }
    },
    selectCancion = function (elm) {
        if (elm.selected() === false) {
            _.each(lista.canciones(), function (e) {
                e.selected(false);
            });
            elm.selected(true);
            cancionS = elm;
        }
        else {
            elm.selected(false);
            cancionS = new zg.cancion();
        }
    },
    selectSugerencia = function (elm) {
        if (elm.selected() === false) {
            _.each(lista.sugerencias(), function (e) { e.selected(false); });
            elm.selected(true);
            sugerenciaS = elm;
        }
        else {
            elm.selected(false);
            sugerenciaS = new zg.cancion();
        }
    },
    //sort
    currentItem    = ko.observable('');
    sortDirection = ko.observable(true),
    columnNames    = ko.observableArray(['Nombre', 'Tipo', 'UltimaVez']),
    sortColumn     = function (item) {
        //if (item == currentItem()) {
        //    sortDirection(!sortDirection());
        //} else {
        //    currentItem(item);
        //    sortDirection(true);
        //}
        //var sorted;
        //if (sortDirection()) {
        //    sorted = listado.sortByProperty(item.toLowerCase())
        //} else {
        //    sorted = listado.sortByProperty(item.toLowerCase()).reverse();
        //}
        //listado(sorted);
    },
    //sort
    up               = function (elm) {
        lista.canciones.move(lista.canciones.indexOf(elm), -1)

    },
    down             = function (elm) {
        lista.canciones.move(lista.canciones.indexOf(elm), 1);
    },
    del              = function (elm) {
        lista.canciones.remove(elm);
        listado.valueHasMutated();
    },
    save             = function (elm) {
        send('/Lista/Save', 'Post', ko.toJSON(lista), function (data) {
            window.location.replace('/Lista/Index');
        });
    },
    edit             = function (elm) {
        window.location.replace('/Lista/Edit'+lista.id());
    },
    swap             = function (elm) {
        if (cancionS.id() !== undefined && sugerenciaS.id() !== undefined)
        {
            lista.canciones.remove(cancionS);
            lista.sugerencias.remove(sugerenciaS);
            lista.canciones.push(sugerenciaS);
            lista.sugerencias.push(cancionS);
        }
    };
    return {
        lista:            lista,         // este objecto contiene todos los datos de la lista
        listado:          listado,       // en este arreglo se carga los listado de las canciones para ser seleccionados
        loadLista:        loadLista,     //este metodo carga la ultima lista que se creo
        loadCanciones:    loadCanciones, //este metodo carga las canciones en el arreglo "listado"
        select:           select,        //metodo para marcar una cancion como seleccionada
        selectSuggest:    selectSuggest, //
        selectSong:       selectSong,    //metodo para marcar en el "listado" las canciones ya marcadas en la "lista.canciones"
        selectCancion:    selectCancion,
        selectSugerencia: selectSugerencia,
        up:               up,
        down:             down,
        del:              del,
        save:             save,
        edit:             edit,
        currentItem:      currentItem,
        sortDirection:    sortDirection,
        columnNames:      columnNames,
        sortColumn:       sortColumn,

    };
};

