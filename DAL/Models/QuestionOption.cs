using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class QuestionOption
    {
        public QuestionOption()
            : this(new QuestionOptionEntity())
        {
        }

        internal QuestionOption(QuestionOptionEntity questionEntity)
        {
            Id = questionEntity.Id;
            OptionText = questionEntity.OptionText;
            QuestionId = questionEntity.QuestionId;
        }

        internal QuestionOptionEntity GetEntity()
        {
            return new QuestionOptionEntity
            {
                Id = this.Id,
                QuestionId = this.QuestionId,
                OptionText = this.OptionText
            };
        }

        public int Id { get; set; }
        public string OptionText { get; set; }
        public int QuestionId { get; set; }
    }
}
