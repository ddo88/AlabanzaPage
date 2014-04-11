var AjaxResult = function (result) {
    var a = result;
    var list = ([]);
    for (var i = 0; i < result.length; i++) {
        var n = new zg.cancion();
        n.nombre(a[i].Nombre);
        n.tipo(a[i].Tipo);
        n.ultimaVez(a[i].UltimaVez);
        n.letra(a[i].Letra);
        n.acordes(a[i].Acordes);
        n.id(a[i].Id);
        list.push(n);
    }
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
            data:data,
            dataType: 'json',
            success: callback
        });
    }
}