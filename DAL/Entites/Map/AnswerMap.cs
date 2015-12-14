using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites.Map
{
    internal class AnswerMap : EntityTypeConfiguration<AnswerEntity>
    {
        public AnswerMap()
        {        
            this.HasKey(x => x.Id);

            this.ToTable("Answer");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Answer).HasColumnName("Answer");
            this.Property(x => x.QuestionId).HasColumnName("QuestionId");
            this.Property(x => x.OptionId).HasColumnName("OptionId");

            this.HasRequired(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x=>x.QuestionId);
        }
    }
}
