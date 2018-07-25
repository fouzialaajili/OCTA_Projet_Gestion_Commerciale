using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public partial class GEN_Model
    {
        
        public long Id { get; set; }

        public string Model { get; set; }

        public long? IdSociete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GEN_Items> GEN_Items { get; set; }

      
    }
}
