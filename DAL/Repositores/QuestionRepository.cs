using DAL.Inerfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositores
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        internal QuestionRepository(IContext context)
        {
            _context = context;
        }


        public ObjectOperationResult<int> GetStatisticByQuestionOption(int id)
        {
            try
            {
                var result = _context.Answers.Count(x => x.OptionId == id);

                return new ObjectOperationResult<int>("Pobrano pomyslnie", result);
            }
            catch (Exception ex)
            {
                return new ObjectOperationResult<int>(false, true, "Bład serwera");
            }
        }
    }
}