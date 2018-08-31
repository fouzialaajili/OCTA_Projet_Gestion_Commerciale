using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_CodesTVAFormViewModel
    {
        public long Id { get; set; }


        public string CodeTaux { get; set; }

        public string LibelleTaux { get; set; }


        public long? TypeTVA { get; set; }

        public int? Percue { get; set; }


        public int? Exonere { get; set; }

        public double? TauxTVA { get; set; }


        public long? IdCompteTVA { get; set; }


        public long? IdRubriqueDeclaration { get; set; }

        public bool Actif { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }
       

        public DateTime? sys_dateCreation { get; set; }

        public CPT_CompteGFormViewModel CPT_CompteG { get; set; }
        public DossierFormViewModel GEN_Dossiers { get; set; }

        public ItemsFormViewModel GEN_Items_RebriqueDeclaration { get; set; }

        public ItemsFormViewModel GEN_Items_TypeTVA { get; set; }


        public ICollection<CPT_CompteGFormViewModel> CPT_CompteG_CodeTVADefault { get; set; }


        public ICollection<CPT_CompteGDetailTVAFormViewModel> CPT_CompteGDetailTVA { get; set; }

        ////public long TvaSocieteId { get; set; }
        ////public DossiersPivot TvaSociete { get; set; }
        public ICollection<TiersFormViewModel> TvaFichetier { get; set; }

    }
}