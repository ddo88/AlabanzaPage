var zg = zg || {};

zg.cancionVM = function () {
    var cancion = new zg.cancion(),
        listado = new ko.observableArray(),
        edit = function ()
        { },
        load = function ()
        {
            //$.ajax({
            //    url: '/Cancion/Listado/',
            //    type: "GET",
            //    dataType: 'json',
            //    success: function (data) {
            //        listado.removeAll();
            //        listado(AjaxResult(data));
            //        listado.valueHasMutated();
            //        Size();
            //    }
            //});
            send('/Cancion/Listado/', 'Get',undefined, function (data) {
                listado.removeAll();
                listado(AjaxResult(data));
                listado.valueHasMutated();});
        },
        saveCancion = function (elm) {
            send('/Cancion/Save/', 'POST', ko.toJSON(elm.cancion), function (res) {
                alert(res.Message);
            });
        };
                     //   $.ajax({
                     //               url: '/Cancion/Save/',
                     //               type: "POST",
                     //               data: ko.toJSON(elm.cancion)
                     //           })
                     //          .success(function (res){
                     //               alert(res.Message);
                     //           });
                     //};

    return {
        cancion: cancion,
        listado: listado,
        load:    load,
        edit:    edit,
        save:    saveCancion
    };
};