using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public partial class GEN_Items
    {
       

        public long Id { get; set; }

        public long? IdModel { get; set; }

        public string Libelle { get; set; }

        public string Valeur { get; set; }

        public int? Ordre { get; set; }
        public virtual GEN_Model GEN_Model { get; set; }



    }
}
