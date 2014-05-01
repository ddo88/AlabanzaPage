﻿var zg = zg || {};

zg.listaVM = function () {
    lista = new zg.lista(),
    listado = ko.observableArray(),
    loadLista = function () {
        send('/Lista/Ultima', 'Get', undefined, function (data) {
            if (data === "") {
            }
            else {
                var i = 0;
                lista.id(data.Id);
                lista.id_usuario(data.IdUsuario);
                lista.fecha(data.Fecha);
                lista.canciones(cancionesListResult(data.Canciones));
                lista.sugerencias(cancionesListResult(data.Sugerencias));
                lista.final(data.Final);
                //lista.valueHasMutated();
            }
        });
    },
    loadCanciones = function () {
        send('/Cancion/Listado/', 'Get', undefined, function (data) {
            listado.removeAll();
            listado(cancionesListResult(data));
            listado.valueHasMutated();
            if (lista.canciones().length > 0)
                selectSong(lista.canciones());
        });
    },
    selectSong = function (elm)
    {
        
        for (var i = 0; i < elm.length; i++)
        {
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
    up = function (elm) {
        lista.canciones.move(lista.canciones.indexOf(elm), -1)

    },
    down = function (elm) {
        lista.canciones.move(lista.canciones.indexOf(elm), 1);
    },
    save= function (elm) {
        send('/Lista/Save/', 'Post', ko.toJSON(elm), function (data) {
            window.location.replace('/Lista/Index');
        })
    };
    return {
        lista:         lista,
        listado:       listado,
        loadLista:     loadLista,
        loadCanciones: loadCanciones,
        select:        select,
        selectSuggest: selectSuggest,
        selectSong:    selectSong,
        up:            up,
        down:          down,
        save:          save
    };
};

//zg.listaVM = function () {
//    lista = new zg.lista(),
//    listado = ko.observableArray(),
//    add = function (elm)
//    {
//        lista.canciones.add(elm);
//    },
//    addSugerencias = function (elm)
//    {
//        lista.sugerencias.add(elm);
//    }
//    edit = function (elm){
//        window.location.replace('/Lista/Edit/' + elm.id());
//    },
//    loadLista = function () {
//        send('/Lista/Ultima', 'Get', undefined, function (data) {
//            listado.removeAll();
//            listado(listaResult(data));
//            listado.valueHasMutated();
//        });
//    },
//    loadCanciones = function () {
//        send('/Cancion/Listado/', 'Get', undefined, function (data) {
//            listado.removeAll();
//            listado(cancionesListResult(data));
//            listado.valueHasMutated();
//            });
//    },
//    remove = function (elm)
//    {
//        lista.canciones.remove(elm);
//    },
//    removeSugerencia = function (elm)
//    {
//        lista.sugerencias.remove(elm);
//    }
//    saveEdited = function (elm) {
//        send('/Lista/Edit/', 'Post', ko.toJSON(elm.cancion), function (data) {
//            window.location.replace('/Lista/Index');
//            })
//    },
//    saveLista = function (elm) {
//        send('/Lista/Save/', 'POST', ko.toJSON(elm.cancion), function (res) {
//            //como redireccionar desde jquery
//            alert(res.Message);
//            });
//    };

//    return {
//        lista: lista,
//        listado: listado,
//        add: add,
//        addSugerencias:addSugerencias,
//        edit: edit,
//        loadCanciones: loadCanciones,
//        remove: remove,
//        removeSugerencia:removeSugerencia,
//        saveEdited: saveEdited,
//        saveLista: saveLista
//    };
//};