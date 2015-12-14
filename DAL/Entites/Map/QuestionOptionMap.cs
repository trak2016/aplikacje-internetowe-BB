using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites.Map
{
    internal class QuestionOptionMap : EntityTypeConfiguration<QuestionOptionEntity>
    {
        public QuestionOptionMap()
        {
            this.HasKey(x=>x.Id);

            this.ToTable("QuestionOption");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.OptionText).HasColumnName("OptionText");
            this.Property(x => x.QuestionId).HasColumnName("QuestionId");

            this.HasRequired(x => x.Question).WithMany(x => x.QuestionOptions).HasForeignKey(x => x.QuestionId);
        }
    }
}
