namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
  
    public partial class EcrituresPivot
    {


        public long Id { get; set; }


        public long? IdPiece { get; set; }


        public DateTime? DateEcriture { get; set; }

        public long? IdCompteG { get; set; }


        public string LibelleEcriture { get; set; }

        public string Reference { get; set; }


        public long? IdTauxTVA { get; set; }


        public double? Taux { get; set; }


        public long? IdDeviceTC { get; set; }

        public double? DebitTC { get; set; }

        public double? CreditTC { get; set; }


        public long? IdDeviceTR { get; set; }


        public double? DebitTR { get; set; }


        public double? CreditTR { get; set; }


        public long? IdTiers { get; set; }
        public long? IdSectionANA { get; set; }
        public long? IdSectionBUD { get; set; }


        public long? IdTypePaiement { get; set; }

        public string CodePointage { get; set; }
        public int? IdentifiantUniqueLettrage { get; set; }
        public long? Rapprochement { get; set; }


        public int? NumOrdre { get; set; }
        public long? IdDossier { get; set; }
        public long? IdDossierSite { get; set; }
        public string sys_user { get; set; }
        public DateTime? sys_dateUpdate { get; set; }
        public DateTime? sys_dateCreation { get; set; }

        public CompteGPivot CPT_CompteG { get; set; }

       
        public  ICollection<EcheancesPivot> CPT_Echeances { get; set; }

        public PiecesPivot CPT_Pieces { get; set; }

        public  DevisesPivot GEN_Devises_TC { get; set; }

        public  DevisesPivot GEN_Devises_TR { get; set; }

        public DossiersSitesPivot GEN_DossiersSites { get; set; }

        public TiersPivot GEN_Tiers { get; set; }
    }
}
