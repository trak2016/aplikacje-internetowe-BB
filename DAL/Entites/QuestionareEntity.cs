using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    internal class QuestionareEntity : EntityBase
    {
        public QuestionareEntity()
        {
            this.Questions = new List<QuestionEntity>();
        }

        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
    }
}
