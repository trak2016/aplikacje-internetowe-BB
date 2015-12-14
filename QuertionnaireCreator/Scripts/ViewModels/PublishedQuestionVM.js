function publishedQuestionVM(lp, source)
{
    var self = this;

    self.id = source.Id;
    self.lp = ko.observable(lp + 1); 
    self.question = ko.observable(source.QuestionText);
    self.answers = ko.observableArray();
    self.singleAnswer = ko.observable(false);
    self.manyAnswer = ko.observable(false);
    self.answerVisible = ko.observable(true);
    self.type = source.Type;

    $.each(source.Options, function (key, value) {
        self.answers.push(new questionOptionVM(lp, self.id, self.type, value.OptionText, value.Id));
    });

    self.unselectAllOptions = function () {
        ko.utils.arrayForEach(self.answers(), function (answer) {
            answer.isSelected(false);
        });
    };

    switch (self.type) {
        case 1:
            self.singleAnswer(true);
            self.manyAnswer(false);
            self.answerVisible(true);
            break;
        case 2:
            self.singleAnswer(false);
            self.manyAnswer(true);
            self.answerVisible(true);
            break;
        case 3:
            self.singleAnswer(false);
            self.manyAnswer(false);
            self.answerVisible(false);
            break;
    };


    self.save = function () {
        switch (self.type) {
            case 1:
                ko.utils.arrayForEach(self.answers(), function (answer) {
                    if(answer.isSelected())
                    {
                        save(answer.id);
                    }
                });
                break;
            case 2:
                self.singleAnswer(false);
                self.manyAnswer(true);
                self.answerVisible(true);
                break;
            case 3:
                self.singleAnswer(false);
                self.manyAnswer(false);
                self.answerVisible(false);
                break;
        };
    };

    function save(optionId) {
        $.post("/Answer/Save", { optionId: optionId, questionId: self.id }, function (result) {
            if (result.HasSucces) {
                
            }
        }).done(function (e) { }).fail(function (e) { });
    };
}