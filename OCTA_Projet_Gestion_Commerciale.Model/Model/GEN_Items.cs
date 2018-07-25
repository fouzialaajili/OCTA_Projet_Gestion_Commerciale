using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Store.Model
{
    public partial class GEN_Items
    {
       

        public long Id { get; set; }

        public long? IdModel { get; set; }

        public string Libelle { get; set; }

        public string Valeur { get; set; }

        public int? Ordre { get; set; }



    }
}
