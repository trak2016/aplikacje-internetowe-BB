function publishedQuestionareVM(id) {
    var self = this;

    self.id = id;
    self.name = ko.observable();
    self.questions = ko.observableArray();
    self.formVisibility = ko.observable(true);

    getQuestionare();

    self.save = function () {
        ko.utils.arrayForEach(self.questions(), function (question) {
            question.save();
        });

        incrementRespondendsNumber();

        self.formVisibility(false);
    };

    self.uncheckAllOptionsByQuestionId = function (id) {
        ko.utils.arrayForEach(self.questions(), function (question) {
            if(question.id == id)
            {
                question.unselectAllOptions();
            }
        });
    };

    function incrementRespondendsNumber() {
        $.post("/Answer/IncrementRespondendsNumber", { id: self.id }, function (result) {
            if (result.HasSucces) {

            }
        }).done(function (e) { }).fail(function (e) { });
    };

    function getQuestionare()
    {
        $.post("/Questionare/GetById", { id: self.id}, function (result) {
            if(result.HasSucces)
            {
                self.id = result.CurrentObject.Id;
                self.name(result.CurrentObject.Name);
                $.each(result.CurrentObject.Questions, function (key, value) {
                    self.questions.push(new publishedQuestionVM(key, value));
                });
            }
        }).done(function (e) { }).fail(function (e) { });
    }
}