using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class ItemsPivot
    {

        public long Id { get; set; }

        public long? IdModel { get; set; }

        public string Libelle { get; set; }

        public string Valeur { get; set; }

        public int? Ordre { get; set; }

        //public virtual GEN_Model GEN_Model { get; set; }

        public virtual ModelPivot GEN_Model { get; set; }

        //public virtual ICollection<CodesTVAPivot> CPT_CodesTVA { get; set; }

        //public virtual ICollection<CodesTVAPivot> CPT_CodesTVA1 { get; set; }


        //public virtual ICollection<CompteGPivot> CPT_CompteG { get; set; }


        //public virtual ICollection<CompteGPivot> CPT_CompteG1 { get; set; }


        //public virtual ICollection<CompteGPivot> CPT_CompteG2 { get; set; }


        //public virtual ICollection<CompteGPivot> CPT_CompteG3 { get; set; }


        //public virtual ICollection<CompteGPivot> CPT_CompteG4 { get; set; }

        //public virtual ICollection<ComptesBancairesPivot> CPT_ComptesBancaires { get; set; }


        //public virtual ICollection<EcheancesPivot> CPT_Echeances { get; set; }

        //public virtual ICollection<JournauxPivot> CPT_Journaux { get; set; }

        //public virtual ICollection<RelevesBancairesDetailPivot> CPT_RelevesBancairesDetail { get; set; }

        //public virtual ICollection<TiersPivot> GEN_Tiers { get; set; }


        //public virtual ICollection<TiersPivot> GEN_Tiers1 { get; set; }


        //public virtual ICollection<TiersPivot> GEN_Tiers2 { get; set; }


        //public virtual ICollection<TypePaiementDetailPivot> GEN_TypePaiementDetail { get; set; }


        //public virtual ICollection<TypePaiementDetailPivot> GEN_TypePaiementDetail1 { get; set; }


        //public virtual ICollection<TypePaiementDetailPivot> GEN_TypePaiementDetail2 { get; set; }
    }
}
