using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class GedFormViewModel
    {
        public long GedId { get; set; }
        public long? GedTypeFichier { get; set; }
        public string GedLibelleFichier { get; set; }
        public string GedDescriptionFichier { get; set; }
        public string GedFichierSource { get; set; }
        public string GedEntiteName { get; set; }
        public long? GedIdEntite { get; set; }
        public long? GedSysuser { get; set; }

        public DateTime? GedSysDateCreation { get; set; }
        public DateTime? GedSysDateUpdate { get; set; }
    }
}