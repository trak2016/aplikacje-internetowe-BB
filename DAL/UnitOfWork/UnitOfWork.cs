using DAL.Inerfaces;
using DAL.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private IContext _context;

        public UnitOfWork()
        {
            _context = new Context.Context();
        }

        private IAnswerRepository _answerRepository;
        private IUserRepository _userRepository;
        private IQuestionareRepository _questionareRepository;
        private IQuestionRepository _questionRepository;

        public IAnswerRepository AnswerRepository
        {
            get { return _answerRepository ?? (_answerRepository = new AnswerRepository(_context)); }
        }
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }
        public IQuestionareRepository QuestionareRepository
        {
            get { return _questionareRepository ?? (_questionareRepository = new QuestionareRepository(_context)); }
        }
        public IQuestionRepository QuestionRepository
        {
            get { return _questionRepository ?? (_questionRepository = new QuestionRepository(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
