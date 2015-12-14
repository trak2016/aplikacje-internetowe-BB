using DAL.Inerfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositores
{
    internal class AnswerRepository : BaseRepository<Answer>, IAnswerRepository
    {
        internal AnswerRepository(IContext context)
        {
            _context = context;
        }
    }
}
