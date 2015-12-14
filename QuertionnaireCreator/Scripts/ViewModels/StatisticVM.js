function statisticVM(id)
{
    var self = this;

    self.id = id;
    self.name = ko.observable();
    self.numberOfRespondends = ko.observable();
    self.questions = ko.observableArray();
    self.formVisibility = ko.observable(true);

    getQuestionare();

    self.save = function () {
        ko.utils.arrayForEach(self.questions(), function (question) {
            question.save();
        });

        self.formVisibility(false);
    };

    self.uncheckAllOptionsByQuestionId = function (id) {
        ko.utils.arrayForEach(self.questions(), function (question) {
            if (question.id == id) {
                question.unselectAllOptions();
            }
        });
    };

    function getQuestionare() {
        $.post("/Statistic/GetByQuestionareId", { id: self.id }, function (result) {
            if (result.HasSucces) { 
                self.id = result.CurrentObject.Id;
                self.name(result.CurrentObject.Name);
                self.numberOfRespondends(result.CurrentObject.numberOfRespondends);
                $.each(result.CurrentObject.Questions, function (key, value) {
                    self.questions.push(new statisticQuestionVM(key, value));
                });
            }
        }).done(function (e) { }).fail(function (e) { });
    }

}