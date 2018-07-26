
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

        public long? IdSociete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ItemsPivot> GEN_Items { get; set; }


    }
}
