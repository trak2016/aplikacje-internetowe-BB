﻿function statisticQuestionVM(lp, source)
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
        self.answers.push(new statisticOptionVM(lp, self.id, value.OptionText, value.Id));
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
}

function statisticOptionVM(lp, questionId, optionText, optionId)
{
    var self = this;

    self.lp = ko.observable(lp);
    self.optionText = ko.observable(optionText);
    self.statistic = ko.observable();
    self.questionId = ko.observable(questionId);

    getStatistic();

    function getStatistic() {
        $.post("/Statistic/GetStatByQuestionOption", { id: optionId }, function (result) {
            if (result.HasSucces) {
                self.statistic(result.CurrentObject);
            }
        }).done(function (e) { }).fail(function (e) { });
    };
}