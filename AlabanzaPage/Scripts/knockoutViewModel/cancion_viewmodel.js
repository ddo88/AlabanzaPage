var zg = zg || {};

zg.cancionVM = function () {
    var cancion = new zg.cancion(),
        listado = new ko.observableArray(),
        edit = function (elm) {
            window.location.replace('/Cancion/Edit/' + elm.id());
            //$.post(, ko.toJSON(elm), function (data) {
                
            //});
            //send('/Cancion/Edit/' + elm.id(), 'Post', ko.toJSON(elm), function (data) {
            //    alert(data);
            //})
        },
        saveEdited = function (elm) {
            send('/Cancion/Edit/', 'Post', ko.toJSON(elm.cancion), function (data) {
                window.location.replace('/Cancion/Index');
            })
        },
        load    = function (){
            send('/Cancion/Listado/', 'Get',undefined, function (data) {
                listado.removeAll();
                listado(cancionesListResult(data));
                listado.valueHasMutated();});},
        saveCancion = function (elm){
            send('/Cancion/Save/', 'POST', ko.toJSON(elm.cancion), function (res) {
                //como redireccionar desde jquery
                alert(res.Message);
            });
        };

    return {
        cancion: cancion,
        listado: listado,
        load:    load,
        edit:    edit,
        save: saveCancion,
        saveEdited: saveEdited
    };
};