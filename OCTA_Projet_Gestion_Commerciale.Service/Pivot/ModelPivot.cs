
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
   public class ModelPivot
    {
        public long Id { get; set; }

        public string Model { get; set; }

       public long? IdDossier { get; set; }

    public ICollection<ItemsPivot> GEN_Items { get; set; }

 public DossiersPivot GEN_Dossiers { get; set; }

    }
}
