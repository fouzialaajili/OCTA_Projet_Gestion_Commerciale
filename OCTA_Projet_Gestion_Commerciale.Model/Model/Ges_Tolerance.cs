using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public class GES_Tolerance
    {
        public long  Id { get; set; }
       public int ToleranceEntier { get; set; }

      public long? ToleranceSocieteId { get; set; }
        public virtual GEN_Dossiers ToleranceSociete { get; set; }

  }
}

