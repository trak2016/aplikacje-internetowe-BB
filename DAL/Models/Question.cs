using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Question
    {
        public Question()
            : this(new QuestionEntity())
        {
        }

        internal Question(QuestionEntity questionEntity)
        {
            Id = questionEntity.Id;
            QuestionText = questionEntity.Question;
            QuestionareId = questionEntity.QuestionareId;
            Type = questionEntity.Type;
            Options = questionEntity.QuestionOptions != null ? questionEntity.QuestionOptions.Select(x=> new QuestionOption(x)).ToList() : new List<QuestionOption>();
        }

        internal QuestionEntity GetEntity()
        {
            return new QuestionEntity
            {
                Id = this.Id,
                Question = this.QuestionText,
                QuestionareId = this.QuestionareId,
                Type = this.Type,
                QuestionOptions = Options.Select(x => x.GetEntity()).ToList()
            };
        }

        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int QuestionareId { get; set; }
        public int Type { get; set; }
        public List<QuestionOption> Options { get; set; }

    }
}
