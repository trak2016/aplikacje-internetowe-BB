using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Answer
    {
        public Answer()
            : this(new AnswerEntity())
        {
        }

        internal Answer(AnswerEntity questionEntity)
        {
            Id = questionEntity.Id;
            AnswerText = questionEntity.Answer;
            QuestionId = questionEntity.QuestionId;
            OptionId = questionEntity.OptionId;
        }

        internal AnswerEntity GetEntity()
        {
            return new AnswerEntity
            {
                Id = this.Id,
                QuestionId = this.QuestionId,
                Answer = this.AnswerText,
                OptionId = this.OptionId
            };
        }

        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
    }
}
