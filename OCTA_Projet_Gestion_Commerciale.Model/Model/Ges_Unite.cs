using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Unite
    {
        public long UniteId { get; set; }
       public string UniteCode { get; set; }

       public string UniteLibelle
     { get; set; }
     public bool UniteActif { get; set; }
       public int UniteSysuser { get; set; }
        public DateTime UniteSysDateCreation { get; set; }
       public DateTime UniteSysDateUpdate { get; set; }
        public long UniteSocieteId { get; set; }
       public virtual  GEN_Dossiers UniteSociete { get; set; }

        public virtual ICollection<GES_Article> UniteArticle { get; set; }
    }
}
 