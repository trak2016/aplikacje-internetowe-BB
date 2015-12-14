using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Questionare
    {
        public Questionare() 
            : this(new QuestionareEntity())
        {
        }

        internal Questionare(QuestionareEntity questionareEntity)
        {
            Id = questionareEntity.Id;
            Name = questionareEntity.Name;
            UserId = questionareEntity.UserId;
            RespondendsNumber = questionareEntity.RespondendsNumber;
            Questions =  questionareEntity.Questions != null ? questionareEntity.Questions.Select(x => new Question(x)).ToList() : null;
        }

        internal QuestionareEntity GetEntity()
        {
            return new QuestionareEntity
            {
                Id = this.Id,
                Name = this.Name,
                UserId = this.UserId,
                RespondendsNumber = this.RespondendsNumber
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public int RespondendsNumber { get; set; }
        public List<Question> Questions { get; set; }
    }
}
