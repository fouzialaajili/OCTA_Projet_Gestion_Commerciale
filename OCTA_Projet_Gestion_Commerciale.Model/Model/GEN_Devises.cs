using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public class GEN_Devises
    {
        
        public long DevisesId { get; set; }
        public string DevisesCode { get; set; }
        public string DevisesCodeIso { get; set; }
        public string DevisesSymbole { get; set; }
        public string DevisesDescription { get; set; }

        public double? DevisesCoursDevise { get; set; }

        public int? DevisesTenueDeCompte { get; set; }

        public bool DevisesActif { get; set; }

        public long? DevisesIdDossier { get; set; }

        public string Devisessys_user { get; set; }

        public DateTime? Devisessys_dateUpdate { get; set; }

        public DateTime? Devisessys_dateCreation { get; set; }


        
        public virtual GEN_Dossiers DeviseSociete { get; set; }

        public virtual ICollection<CPT_ComptesBancaires> CPT_ComptesBancaires { get; set; }

        public virtual ICollection<CPT_ComptesBancairesTiers> CPT_ComptesBancairesTiers { get; set; }

        public virtual ICollection<CPT_Ecritures> CPT_Ecritures_TC { get; set; }

        public virtual ICollection<CPT_Ecritures> CPT_Ecritures_TR { get; set; }

        public virtual ICollection<CPT_Journaux> CPT_Journaux { get; set; }

        public virtual ICollection<CPT_Pieces> CPT_Pieces_TC { get; set; }

        public virtual ICollection<CPT_Pieces> CPT_Pieces_TR { get; set; }
        public virtual ICollection<CPT_RelevesBancaires> CPT_RelevesBancaires { get; set; }

     

   
        public virtual ICollection<GEN_Tiers> GEN_Tiers { get; set; }
        public virtual ICollection<GES_Opportunite> GES_Opportunite { get; set; }
    }
}
