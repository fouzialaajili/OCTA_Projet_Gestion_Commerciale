using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class GEN_Model_Form_ViewModel
    {
        public long Id { get; set; }

        public string Model { get; set; }

        public long? IdDossier { get; set; }
      public ICollection<GEN_Items_Form_ViewModel> GEN_Items { get; set; }

    public GEN_Dossiers_Form_ViewModel GEN_Dossiers { get; set; }

    }
}