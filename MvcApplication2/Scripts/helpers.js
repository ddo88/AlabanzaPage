/* File Created: febrero 23, 2014 */

function Size() {
    $("#contenedor").css("height", $("#canciones_list").height());    
};

var AjaxResult = function (result) {
    var a = result.Canciones;
    var list = ([]);

    for (var i = 0; i < result.Canciones.length; i++) {
        var n = new zg.cancion();
        n.nombre(a[i].Nombre);
        n.tipo(a[i].Tipo);
        n.ultimaVez(a[i].UltimaVez);
        list.push(n);
    }
    return list;
};

var CompareNameAsc  = function (a, b) {
    if (a.nombre() < b.nombre())//<
        return -1;
    if (a.nombre() > b.nombre())
        return 1;
    // a must be equal to b
    return 0;
};
var CompareNameDesc = function (a, b) {
    if (a.nombre() > b.nombre())//<
        return -1;
    if (a.nombre() < b.nombre())
        return 1;
    // a must be equal to b
    return 0;
};
var CompareDateAsc  = function (a, b) {
    if (a.ultimaVez() < b.ultimaVez())//<
        return -1;
    if (a.ultimaVez() > b.ultimaVez())
        return 1;
    // a must be equal to b
    return 0;
};
var CompareDateDesc = function (a, b) {
    if (a.ultimaVez() > b.ultimaVez())//<
        return -1;
    if (a.ultimaVez() < b.ultimaVez())
        return 1;
    // a must be equal to b
    return 0;
};
