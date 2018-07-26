using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    public class CPT_ClasseConfiguration : EntityTypeConfiguration<CPT_Classe>
    {public CPT_ClasseConfiguration()
        {
            ToTable("CPT_Classe");
            HasKey(x => x.Id);
            HasOptional<CPT_Classe>(a => a.CPT_Classe_Parent)
        .WithMany(d => d.CPT_Classe_Childs)
         .HasForeignKey<long?>(a => a.IdClasse);
            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
        .WithMany(d => d.CPT_Classe)
         .HasForeignKey<long?>(a => a.IdClasse);

             

    }
    }
}
