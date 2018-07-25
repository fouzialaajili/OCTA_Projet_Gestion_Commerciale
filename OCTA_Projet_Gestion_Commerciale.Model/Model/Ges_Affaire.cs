using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Affaire
    {
         public long AffaireId { get; set; }
         public string AffaireCode { get; set; }
      public string AffaireLibelle
        { get; set; }

   
        public int AffaireSysuser { get; set; }
        public DateTime AffaireSysDateCreation { get; set; }
        public DateTime AffaireSysDateUpdate { get; set; }

        public long AffaireSocieteId { get; set; }
        public virtual GEN_Dossiers AffaireSociete { get; set; }

    }
}
