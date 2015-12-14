function manageVM() {
    var self = this;

    self.questionares = ko.observableArray();

    getQuestionares();

    function getQuestionares() {
        $.post("/Questionare/GetList", { id: self.id }, function (result) {
            if (result.HasSucces) {
                $.each(result.CurrentObject, function (key, value) {
                    self.questionares.push(new questionareManageListItem(value));
                });
            }
        }).done(function (e) { }).fail(function (e) { });
    };
};

function questionareManageListItem(source) {
    var self = this;

    self.id = source.Id;
    self.name = ko.observable(source.Name);

    self.selected = function () {
        location.href = '/Statistic/Index?id=' + self.id;
    };
}