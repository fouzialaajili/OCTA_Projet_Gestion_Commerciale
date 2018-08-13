using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ModelViewModel
    {
        public long Id { get; set; }

        public string Model { get; set; }

        public long? IdSociete { get; set; }
    }
}