using DAL.Inerfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositores
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        internal QuestionRepository(IContext context)
        {
            _context = context;
        }
    }
}
