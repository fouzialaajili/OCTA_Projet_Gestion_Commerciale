using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class UniteFormViewModel
    {
        public long Id { get; set; }
        public string UniteCode { get; set; }

        public string UniteLibelle
        { get; set; }
        public bool UniteActif { get; set; }
        public int UniteSysuser { get; set; }
        public DateTime UniteSysDateCreation { get; set; }
        public DateTime UniteSysDateUpdate { get; set; }
        public long? UniteSocieteId { get; set; }
    }
}