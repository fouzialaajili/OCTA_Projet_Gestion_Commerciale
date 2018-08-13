namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
  

    public partial class PiecesPivot
    {

        public long Id { get; set; }

        public long? TypePiece { get; set; }

        public string OriginePiece { get; set; }

        public DateTime? DatePiece { get; set; }

        public DateTime? DateReference { get; set; }

        public DateTime? DateFacture { get; set; }

        public string RefPiece { get; set; }

        public long? IdTiers { get; set; }

        public long? IdJournal { get; set; }


        public string NumPiece { get; set; }

        public string Libelle { get; set; }

        public double? CourChange { get; set; }

        public long? IdDeviseTC { get; set; }


        public long? IdDeviseTR { get; set; }


        public long? IdDossier { get; set; }

        public long? IdDossierSite { get; set; }


        public int? Brouillon { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public JournauxPivot CPT_Journaux { get; set; }

        public DevisesPivot GEN_DevisesTC { get; set; }

        public DevisesPivot GEN_DevisesTR { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

        public DossiersSitesPivot GEN_DossiersSites { get; set; }

        public TiersPivot GEN_Tiers { get; set; }

      
        public  ICollection<EcrituresPivot> CPT_Ecritures { get; set; }

      
    }
}
