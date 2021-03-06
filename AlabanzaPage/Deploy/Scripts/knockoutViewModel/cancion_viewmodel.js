﻿var zg = zg || {};

zg.cancionVM = function () {
    var cancion     = new zg.cancion(),
        listado     = new ko.observableArray(),
        edit        = function (elm) {
            window.location.replace('/Cancion/Edit' + elm.id());
        },
        verLetra    = function (elm)
        {
            var i = 0;
        },
        saveEdited  = function (elm) {
            send('/Cancion/SaveEdit', 'Post', { dataEdit: ko.toJSON(elm.cancion) }, function (data) {
                window.location.replace('/Cancion/Index');
            })
        },
        load        = function ()   {
            send('/Cancion/Listado', 'Get',undefined, function (data) {
                listado.removeAll();
                listado(cancionesListResult(data));
                listado.valueHasMutated();});},
        saveCancion = function (elm){
            send('/Cancion/Save', 'POST', { dataSave: ko.toJSON(elm.cancion) }, function (res) {
                alert(res.Message);
            });
        };
    return {
        cancion:    cancion,
        listado:    listado,
        load:       load,
        edit:       edit,
        verLetra:   verLetra,
        save:       saveCancion,
        saveEdited: saveEdited
    };
};