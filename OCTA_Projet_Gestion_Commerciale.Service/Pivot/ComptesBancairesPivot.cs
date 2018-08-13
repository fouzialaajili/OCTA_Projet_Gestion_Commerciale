namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;


    public partial class ComptesBancairesPivot
    {


        public long Id { get; set; }

        public long? IdBanque { get; set; }

        public string NomAgence { get; set; }

        public string Adresse { get; set; }

        public string Contact { get; set; }


        public string Tel { get; set; }


        //[IsRIBUnique]      
        public string RIB { get; set; }

        public long? IdDevise { get; set; }

        public bool Actif { get; set; }

        public bool ParDefault { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public long? IdCompteG { get; set; }

        public CompteGPivot CPT_CompteG { get; set; }

        public DevisesPivot GEN_Devises { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

        public ItemsPivot GEN_Items { get; set; }

        public  ICollection<RelevesBancairesPivot> CPT_RelevesBancaires { get; set; }
    }
}
