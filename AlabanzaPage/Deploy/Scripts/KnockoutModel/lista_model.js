﻿var zg = zg || {};
zg.lista = function (){
    this.id          = ko.observable();
    this.idUsuario  = ko.observable();
    this.canciones   = ko.observableArray();
    this.sugerencias = ko.observableArray();
    //this.canciones   = ko.observable();
    this.final = ko.observable();
    this.fecha = ko.observable();
};