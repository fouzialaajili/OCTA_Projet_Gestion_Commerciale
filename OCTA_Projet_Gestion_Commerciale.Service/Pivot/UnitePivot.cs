
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class UnitePivot
    {
        public long Id { get; set; }
        public string UniteCode { get; set; }

        public string UniteLibelle
        { get; set; }
        public bool UniteActif { get; set; }
        public int UniteSysuser { get; set; }
        public DateTime UniteSysDateCreation { get; set; }
        public DateTime UniteSysDateUpdate { get; set; }
        public long UniteSocieteId { get; set; }
        public  DossiersPivot UniteSociete { get; set; }

        public  ICollection<GES_Article> UniteArticle { get; set; }
    }
}
