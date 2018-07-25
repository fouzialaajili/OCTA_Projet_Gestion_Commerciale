
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class GES_CategorieConfiguration : EntityTypeConfiguration<GES_Categorie>
    {
        public GES_CategorieConfiguration()
        {
            ToTable("Categorie");
            HasKey(a => a.CategorieId);
            HasOptional<GEN_Dossiers>(a => a.CategorieSociete)
.WithMany(d => d.SocieteCategorie)
.HasForeignKey<long?>(a => a.CategorieSocieteId);
             
    }
    }
}
