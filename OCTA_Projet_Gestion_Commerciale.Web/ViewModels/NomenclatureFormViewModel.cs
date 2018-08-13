using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class NomenclatureFormViewModel
    {
        public long NomenclatureId { get; set; }
        public int ArticlenomencId { get; set; }
        public string NomenclatureLib { get; set; }
        public int NomenclatureQuantite { get; set; }
        public int NomenclatureSysuser { get; set; }
        public DateTime? NomenclatureSysDateCreation { get; set; }
        public DateTime? NomenclatureSysDateUpdate { get; set; }
        /***/
        public long? NomenclatureIdarticle { get; set; }
    }
}