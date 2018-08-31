namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
 

    public partial class RelevesBancairesPivot
    {

        public long Id { get; set; }

        public DateTime? DateIntegration { get; set; }

        public long? IdCompteBancaire { get; set; }

        public long? IdDevise { get; set; }
        public string Description { get; set; }

        public double? SoldeDebut { get; set; }

        public double? SoldeFin { get; set; }

        [DefaultValue(true)]
        public bool Valide { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public byte[] Fichier { get; set; }


        //public ComptesBancairesPivot  CPT_ComptesBancaires { get; set; }

        //public  DevisesPivot GEN_Devises { get; set; }


        //public ICollection<RelevesBancairesDetailPivot> CPT_RelevesBancairesDetail { get; set; }

      

        
    }
}
