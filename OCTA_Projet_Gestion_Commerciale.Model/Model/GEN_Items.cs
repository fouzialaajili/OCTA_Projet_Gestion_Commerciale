using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OCTA_Projet_Gestion_Commerciale.Model
{
    public partial class GEN_Items
    {
        public long Id { get; set; }

        public long? IdModel { get; set; }

        public string Libelle { get; set; }

        public string Valeur { get; set; }

        public int? Ordre { get; set; }

        public virtual GEN_Model GEN_Model { get; set; }
        /***************/

        //public virtual ICollection<CPT_CodesTVA> CPT_CodesTVA { get; set; }

        //public virtual ICollection<CPT_CodesTVA> CPT_CodesTVA1 { get; set; }


        //public virtual ICollection<CPT_CompteG> CPT_CompteG { get; set; }


        //public virtual ICollection<CPT_CompteG> CPT_CompteG1 { get; set; }


        //public virtual ICollection<CPT_CompteG> CPT_CompteG2 { get; set; }


        //public virtual ICollection<CPT_CompteG> CPT_CompteG3 { get; set; }


        //public virtual ICollection<CPT_CompteG> CPT_CompteG4 { get; set; }

        //public virtual ICollection<CPT_ComptesBancaires> CPT_ComptesBancaires { get; set; }


        //public virtual ICollection<CPT_Echeances> CPT_Echeances { get; set; }

        //public virtual ICollection<CPT_Journaux> CPT_Journaux { get; set; }

        //public virtual ICollection<CPT_RelevesBancairesDetail> CPT_RelevesBancairesDetail { get; set; }

        //public virtual ICollection<GEN_Tiers> GEN_Tiers { get; set; }


        //public virtual ICollection<GEN_Tiers> GEN_Tiers1 { get; set; }


        //public virtual ICollection<GEN_Tiers> GEN_Tiers2 { get; set; }


        //public virtual ICollection<GEN_TypePaiementDetail> GEN_TypePaiementDetail { get; set; }


        //public virtual ICollection<GEN_TypePaiementDetail> GEN_TypePaiementDetail1 { get; set; }


        //public virtual ICollection<GEN_TypePaiementDetail> GEN_TypePaiementDetail2 { get; set; }



    }
}
