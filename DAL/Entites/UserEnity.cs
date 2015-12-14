using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    internal class UserEntity : EntityBase
    {
        public string Name { get; set; }
        public string MembershipId { get; set; }

        public virtual ICollection<QuestionareEntity> Questionares { get; set; }
    }
}
