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
    public class QuestionareRepository : BaseRepository<Questionare>, IQuestionareRepository
    {
        internal QuestionareRepository(IContext context)
        {
            _context = context;
        }

        public ObjectOperationResult<Questionare> Get(int id)
        {
            try
            {
                var questionare = _context.Questionares.Include(x => x.Questions.Select(y => y.QuestionOptions)).FirstOrDefault(x=>x.Id == id);

                if(questionare == null)
                {
                    return new ObjectOperationResult<Questionare>(false, false, "Nie istnieje");
                }

                return new ObjectOperationResult<Questionare>("Pobrano pomyślnie", new Questionare(questionare));
            }
            catch (Exception)
            {

                return new ObjectOperationResult<Questionare>(false, true, "Błąd serwera podczas pobierania kwestionariusza ");
            }
        }


        public ObjectOperationResult<IEnumerable<Questionare>> GetList(int userId)
        {
            try
            {
                var questionare = _context.Questionares.Where(x => x.UserId == userId).ToList().Select(x=>new Questionare(x)).ToList();

                return new ObjectOperationResult<IEnumerable<Questionare>>("Pobrano pomyślnie", questionare);
            }
            catch (Exception ex)
            {
               return new ObjectOperationResult<IEnumerable<Questionare>>(false, true, "Błąd serwera podczas pobierania kwestionariusza ");
            }
        }


        public void IncrementQuestionareNumber(int questionId)
        {
            try
            {
                var question = _context.Questions.FirstOrDefault(x=>x.Id == questionId);
                var questionare = _context.Questionares.FirstOrDefault(x => x.Id == question.QuestionareId);

                questionare.RespondendsNumber++;

                _context.SaveChanges();

            }
            catch (Exception ex)
            {              
                throw;
            }
        }
    }
}
