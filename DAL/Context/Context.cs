using DAL.Entites;
using DAL.Entites.Map;
using DAL.Inerfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    internal class Context : DbContext, IContext
    {
        static Context()
        {
            Database.SetInitializer<Context>(null);
        }

        internal Context()
            : base("NAME=Context")
        { }

        public IDbSet<AnswerEntity> Answers
        {
            get { return Set<AnswerEntity>(); }
        }
        public IDbSet<QuestionareEntity> Questionares
        {
            get { return Set<QuestionareEntity>(); }
        }
        public IDbSet<QuestionEntity> Questions
        {
            get { return Set<QuestionEntity>(); }
        }
        public IDbSet<QuestionOptionEntity> QuestionOptions
        {
            get { return Set<QuestionOptionEntity>(); }
        }
        public IDbSet<UserEntity> Users
        {
            get { return Set<UserEntity>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnswerMap());
            modelBuilder.Configurations.Add(new QuestionareMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new QuestionOptionMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
