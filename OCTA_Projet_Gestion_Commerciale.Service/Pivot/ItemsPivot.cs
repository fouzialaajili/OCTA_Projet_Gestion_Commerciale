using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class ItemsPivot
    {

        public long Id { get; set; }

        public long? IdModel { get; set; }

        public string Libelle { get; set; }

        public string Valeur { get; set; }

        public int? Ordre { get; set; }
    }
}
