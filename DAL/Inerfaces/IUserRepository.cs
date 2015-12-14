using DAL.Models;
using DAL.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        ObjectOperationResult<User> GetByMembershipId(string p);
    }
}
