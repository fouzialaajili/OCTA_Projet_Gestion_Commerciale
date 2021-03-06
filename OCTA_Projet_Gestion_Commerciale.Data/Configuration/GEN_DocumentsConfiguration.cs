﻿using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GEN_DocumentsConfiguration: EntityTypeConfiguration<GEN_Documents>
    {
        //  public virtual GEN_Dossiers GEN_Dossiers { get; set; }
        // public virtual ICollection<GEN_Documents> GEN_Documents { get; set; }
        public GEN_DocumentsConfiguration()
        {
            ToTable("GEN_Document");
            HasKey(a => a.Id);


            HasOptional<GEN_Dossiers>(a => a.GEN_Dossiers)
         .WithMany(d => d.GEN_Documents)
       .HasForeignKey<long?>(a => a.IdDossier);
        }

    }
}
