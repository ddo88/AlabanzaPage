var zg = zg || {};
zg.usuario  = function () {
    this.id    = ko.observable();
    this.user  = ko.observable();
    this.pass  = ko.observable();
    this.roles = ko.observableArray();    
};