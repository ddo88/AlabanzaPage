var zg = zg || {};
zg.cancion = function () {
    this.id      = ko.observable();
    this.nombre  = ko.observable();
    this.tipo    = ko.observable();
    this.letra   = ko.observable();
    this.ultimaVez = ko.observable();
    this.selected = ko.observable(false);
};


