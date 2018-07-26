
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
   public class SocietesPivot
    {
        public long Id { get; set; }

        public string RaisonSociale { get; set; }


        public DateTime? DateCommande { get; set; }

        public string NumeroCommande { get; set; }

        public int NombreUser { get; set; }

        public int NombreDossiers { get; set; }


        public DateTime DateEcheance { get; set; }

        public int Actif { get; set; }

        public string CleSecurite { get; set; }

        public string Sys_user { get; set; }

        public DateTime? Sys_dateUpdate { get; set; }

        public DateTime? Sys_dateCreation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<DossiersPivot> GEN_Dossiers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public  ICollection<ModelPivot> GEN_Model { get; set; }
    }
}
