using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerfaces
{
    internal interface IContext
    {
        IDbSet<AnswerEntity> Answers { get; }
        IDbSet<QuestionareEntity> Questionares { get; }
        IDbSet<QuestionEntity> Questions { get; }
        IDbSet<QuestionOptionEntity> QuestionOptions { get; }
        IDbSet<UserEntity> Users { get; }

        int SaveChanges();
        void Dispose();
    }
}
