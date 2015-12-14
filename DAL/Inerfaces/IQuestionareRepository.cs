using DAL.Models;
using DAL.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerfaces
{
    public interface IQuestionareRepository : IBaseRepository<Questionare>
    {
        ObjectOperationResult<Questionare> Get(int id);
        ObjectOperationResult<IEnumerable<Questionare>> GetList(int userId);
        void IncrementQuestionareNumber(int questionId);
    }
}
