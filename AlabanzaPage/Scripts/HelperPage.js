
var cancionesListResult = function (result) {
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

var cancionResult = function (result) {
    var a = result;
    
    var n = new zg.cancion();
        n.nombre(a.Nombre);
        n.tipo(a.Tipo);
        n.ultimaVez(a.UltimaVez);
        n.letra(a.Letra);
        n.acordes(a.Acordes);
        n.id(a.Id);
        return n;    
};

var listaResult = function (result) {
    var a = result;

    var n = new zg.cancion();
    n.nombre(a.Nombre);
    n.tipo(a.Tipo);
    n.ultimaVez(a.UltimaVez);
    n.letra(a.Letra);
    n.acordes(a.Acordes);
    n.id(a.Id);
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
            data:data,
            dataType: 'json',
            success: callback
        });
    }
}