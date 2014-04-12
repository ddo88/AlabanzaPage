var zg = zg || {};
zg.cancion = function () {
    this.id      = ko.observable();
    this.nombre  = ko.observable();
    this.tipo    = ko.observable();
    this.letra   = ko.observable();
    this.acordes = ko.observable();
    this.ultimaVez = ko.observable();
    this.cls = ko.computed(function () {
        if (this.tipo() !== undefined)
            return this.tipo().toLowerCase();
        return this.tipo();
    }, this);
};


ko.bindingHandlers.date = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var valueUnwrapped = ko.utils.unwrapObservable(valueAccessor());
        var textContent = moment(valueUnwrapped).format("YYYY-MM-DD");
        ko.bindingHandlers.text.update(element, function () { return textContent; });
    }
};

ko.bindingHandlers.dateString = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor(),allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);
        var pattern = allBindings.datePattern || 'YYYY-MM-DD';
        $(element).text(valueUnwrapped.toString(pattern));
    }
}