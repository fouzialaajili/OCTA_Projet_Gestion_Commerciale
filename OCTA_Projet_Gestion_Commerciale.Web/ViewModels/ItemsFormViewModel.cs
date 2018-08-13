using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ItemsFormViewModel
    {
        public long Id { get; set; }

        public long? IdModel { get; set; }

        public string Libelle { get; set; }

        public string Valeur { get; set; }

        public int? Ordre { get; set; }
        public  ModelFormViewModel GEN_Model { get; set; }
    }
}