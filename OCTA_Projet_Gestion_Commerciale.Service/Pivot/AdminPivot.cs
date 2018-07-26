using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class AdminPivot
    {
        public long Id { get; set; }
        public string AdminLogin { get; set; }
        public string AdminPassword { get; set; }
        public bool AdminActif { get; set; }
    }
}
