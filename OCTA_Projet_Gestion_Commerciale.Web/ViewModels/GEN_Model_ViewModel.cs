using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class GEN_Model_ViewModel
    {  public long Id { get; set; }

        public string Model { get; set; }
        public long? IdDossier { get; set; }

   /*     public  ICollection<GEN_Items> GEN_Items {
            get;
            set;
        }

        public GEN_Dossiers GEN_Dossiers { get; set; }
        */
    }
}