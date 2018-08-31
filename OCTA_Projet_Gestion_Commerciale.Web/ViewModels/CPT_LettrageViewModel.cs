using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_LettrageViewModel
    {
        public long Id { get; set; }

        public long? IdEcheance { get; set; }

        public double? MontantRegle { get; set; }

        public string CodeLettrage { get; set; }

        public DateTime? DateLettrage { get; set; }



        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public CPT_EcheancesViewModel CPT_Echeances { get; set; }

        public ICollection<CPT_TVALettrageViewModel> CPT_TVALettrage { get; set; }
    }
}