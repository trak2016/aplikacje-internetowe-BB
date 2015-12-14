using DAL.Inerfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositores
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        internal UserRepository(IContext context)
        {
            _context = context;
        }

        public ObjectOperationResult<User> GetByMembershipId(string p)
        {
            try
            {
                var userEntity = _context.Users.FirstOrDefault(x => x.MembershipId == p);

                return new ObjectOperationResult<User>("Pobrano pomyślnie", new User(userEntity));
            }
            catch (Exception)
            {
                return new ObjectOperationResult<User>(false ,true, "Błąd serwera podczas pobierania użytkownika");
            }
        }
    }
}
