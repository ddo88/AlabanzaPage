var zg = zg || {};

zg.listaVM = function () {
    lista = new zg.lista(),
    listado = ko.observableArray(),
    loadLista = function () {
        send('/Lista/Ultima', 'Get', undefined, function (data) {
            if (data === "")
            { }
            else
            {
                //codigo cuando recibo un lista de verdad
                //listado.removeAll();
                //listado(listaResult(data));
                //listado.valueHasMutated();
            }            
        });
    },
    loadCanciones = function () {
        send('/Cancion/Listado/', 'Get', undefined, function (data) {
            listado.removeAll();
            listado(cancionesListResult(data));
            listado.valueHasMutated();
        });
    },
    select = function (elm)
    {
        if (elm.selected() === false)
        {
            elm.selected(true);
            lista.canciones.push(elm);
        }
        else
        {
            elm.selected(false);
            lista.canciones.remove(elm);
        }
        

        
        //lista.canciones.add(elm);
    };

    return {
        lista:         lista,
        listado:       listado,
        loadLista:     loadLista,
        loadCanciones: loadCanciones,
        select:select
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