namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
   

    public partial class JournauxPivot
    {


        public long Id { get; set; }


        public string CodeJournal { get; set; }


        public string Libelle { get; set; }

        public long? TypeJournal { get; set; }


        public long? IdCompteContrepartie { get; set; }

        public long? IdDossier { get; set; }


        public long? IdDevise { get; set; }

        public bool Actif { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_DateUpdate { get; set; }

        public DateTime? sys_DateCreation { get; set; }

        public CompteGPivot CPT_CompteG { get; set; }

        public  DevisesPivot GEN_Devises { get; set; }

        public  DossiersPivot GEN_Dossiers { get; set; }

        public ItemsPivot GEN_Items { get; set; }

        public  ICollection<ParametrageComptablePivot> CPT_ParametrageComptable { get; set; }

 
        public  ICollection<PiecesPivot> CPT_Pieces { get; set; }

     
        public  ICollection<RegelementPivot> GEN_Regelement { get; set; }
    }
}
