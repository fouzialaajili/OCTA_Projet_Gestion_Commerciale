using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public class GES_ReglementFacture
    {
       public long ReglementFactureId { get; set; }
        public long? ReglementId { set; get; }
       /****/ public long? ReglementFactureIdfacture { set; get; }
        public long? ReglementFacturePaye{ set; get; }

}
}
