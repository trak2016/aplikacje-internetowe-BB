﻿using DAL.Models;
using DAL.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Inerfaces
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        ObjectOperationResult<int> GetStatisticByQuestionOption(int id);
    }
}
