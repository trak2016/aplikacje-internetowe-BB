using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites.Map
{
    internal class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            this.HasKey(x=>x.Id);

            this.ToTable("User");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.MembershipId).HasColumnName("MembershipId");
        }
    }
}
