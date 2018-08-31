
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
   public class DocumentsPivot
    {
        public long Id { get; set; }

        public string Libelle { get; set; }

        public string Tags { get; set; }

        public string Fichier { get; set; }

        public string NomObjetClasse { get; set; }

        public int IdObjet { get; set; }

        public long IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

      //  public virtual GEN_Dossiers GEN_Dossiers { get; set; }

       // public DossiersPivot GEN_Dossiers { get; set; }
    }
}
