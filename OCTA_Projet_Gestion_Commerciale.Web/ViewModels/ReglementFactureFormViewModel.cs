using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ReglementFactureFormViewModel
    {
        public long ReglementFactureId { get; set; }
        public long? ReglementId { set; get; }
        /****/
        public long? ReglementFactureIdfacture { set; get; }
        public long? ReglementFacturePaye { set; get; }

    }
}