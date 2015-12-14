using DAL.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerfaces
{
    public interface IBaseRepository<T>
    {
        ObjectOperationResult<T> Add(T item);
    }
}
