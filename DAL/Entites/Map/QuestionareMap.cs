using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites.Map
{
    internal class QuestionareMap : EntityTypeConfiguration<QuestionareEntity>
    {
        public QuestionareMap()
        {
            this.HasKey(x=>x.Id);

            this.ToTable("Questionare");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.UserId).HasColumnName("UserId");

            this.HasMany(x => x.Questions).WithRequired(x => x.Questionare).HasForeignKey(x => x.QuestionareId);
            this.HasRequired(x => x.User).WithMany(x => x.Questionares).HasForeignKey(x => x.UserId);
        }
    }
}
