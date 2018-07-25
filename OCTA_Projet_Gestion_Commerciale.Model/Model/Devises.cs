using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class Devises
    {
        public long  DevisesId { get; set; }
        public string DevisesCode { get; set; }
        public string DevisesCodeIso { get; set; }
        public string  DevisesDescription { get; set; }
        public Double DevisesCoursDevise { get; set; }
        public bool DevisesTenuedecompte { get; set; }
        public bool DevisesTenuedeActif { get; set; }
        public int DevisesSysuser { get; set; }
        public DateTime DevisesSysDateCreation { get; set; }
        public DateTime DevisesSysDateUpdate { get; set; }
        public long  DevisesSocieteId { get; set; }
        public Societe DevisesSociete { get; set; }
        public virtual ICollection<Opportunite> DeviseOpportunite { get; set; }
    }
}
