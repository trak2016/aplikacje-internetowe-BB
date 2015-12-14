using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public User() :
            this(new UserEntity())
        {
        }

        internal User(UserEntity userEntity)
        {
            this.Id = userEntity.Id;
            this.Name = userEntity.Name;
            this.MembershipId = userEntity.MembershipId;
        }

        internal UserEntity GetEntity()
        {
            return new UserEntity
            {
                Name = this.Name,
                MembershipId = this.MembershipId,
                Id = this.Id
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string MembershipId { get; set; }

    }
}
