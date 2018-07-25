namespace Store.Model
{
    using System;
    using System.Collections.Generic;


    public partial class CPT_ParametrageComptable
    {
        public long CPT_ParametrageComptableId { get; set; }
     
        public string NumeroPiece { get; set; }

        public long? IdJournalANouveaux { get; set; }
      
        public long? IdJournalAchatIntegration { get; set; }
 
        public long? IdJournalVenteIntegration { get; set; }
     
        public bool ModeBrouillardActive { get; set; }

       
        public string LibelleEcritureANouveau { get; set; }

     
        public string LibelleEcriturePiece { get; set; }

        
        public long? IdCompteBenefice { get; set; }

    
        public long? IdCompteDeficit { get; set; }

        
        public long? IdCompteEcartPaiementVente { get; set; }

        
        public long? IdCompteEcartPaiementAchat { get; set; }

        public long? IdCompteCollectifClient { get; set; }

      
        public long? IdCompteCollectifFournisseur { get; set; }

     
        public long? IdCompteEcartPerte { get; set; }

      
        public long? IdCompteEcartGain { get; set; }
    
        public long? IdJournalBanque { get; set; }

        public long? IdDossier { get; set; }
        
        public bool InterdirLaGenFact { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual CPT_CompteG CPT_CompteG { get; set; }

        public virtual CPT_CompteG CPT_CompteG_CompteDeficit { get; set; }

        public virtual CPT_Journaux CPT_Journaux { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }
    }
}
