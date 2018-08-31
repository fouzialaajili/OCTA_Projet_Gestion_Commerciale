using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class AffaireFormViewModel
    {
        public long AffaireId { get; set; }
        public string AffaireCode { get; set; }
        public string AffaireLibelle
        { get; set; }


        public int AffaireSysuser { get; set; }
        public DateTime? AffaireSysDateCreation { get; set; }
        public DateTime? AffaireSysDateUpdate { get; set; }

        public long? AffaireSocieteId { get; set; }

        public GEN_Dossiers_Form_ViewModel AffaireSociete { get; set; }
    }
}