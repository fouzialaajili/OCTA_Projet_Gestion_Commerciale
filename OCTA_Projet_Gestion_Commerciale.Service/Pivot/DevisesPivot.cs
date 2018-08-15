using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class DevisesPivot
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
        public DossiersPivot GEN_Dossiers { get; set; }

        public ICollection<ComptesBancairesPivot> CPT_ComptesBancaires { get; set; }

        public ICollection<ComptesBancairesTiersPivot> CPT_ComptesBancairesTiers { get; set; }

        public ICollection<EcrituresPivot> CPT_Ecritures_TC { get; set; }

        public ICollection<EcrituresPivot> CPT_Ecritures_TR { get; set; }

        public ICollection<JournauxPivot> CPT_Journaux { get; set; }

        public ICollection<PiecesPivot> CPT_Pieces_TC { get; set; }

        public ICollection<PiecesPivot> CPT_Pieces_TR { get; set; }
        public ICollection<RelevesBancairesPivot> CPT_RelevesBancaires { get; set; }
      //  public ICollection<TiersPivot> GEN_Tiers { get; set; }
        public ICollection<OpportunitePivot> GES_Opportunite { get; set; }









    }
}

