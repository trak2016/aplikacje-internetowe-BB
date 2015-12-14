using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites.Map
{
    internal class QuestionMap : EntityTypeConfiguration<QuestionEntity>
    {
        public QuestionMap()
        {
            this.HasKey(x => x.Id);

            this.ToTable("Question");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.QuestionareId).HasColumnName("QuestionareId");
            this.Property(x => x.Type).HasColumnName("Type");
        }
    }
}
