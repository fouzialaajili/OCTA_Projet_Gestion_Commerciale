using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public partial class GEN_Model
    {   public long Id { get; set; }

        public string Model { get; set; }
        public long? IdDossier { get; set; }

        public virtual ICollection<GEN_Items> GEN_Items {
            get;
            set;
        }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

    }
}
