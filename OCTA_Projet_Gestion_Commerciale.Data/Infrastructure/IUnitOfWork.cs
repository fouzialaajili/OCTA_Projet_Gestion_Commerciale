﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
