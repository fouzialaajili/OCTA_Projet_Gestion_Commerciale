using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class TypePaiementViewModel
    {
        public long TypePaiementId { get; set; }

        public string Libelle { get; set; }

        public bool Actif { get; set; }
        public long? IdDossier { get; set; }
    }
}