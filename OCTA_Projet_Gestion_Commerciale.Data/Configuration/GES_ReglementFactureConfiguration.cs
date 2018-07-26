
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Configuration
{
    class GES_ReglementFactureConfiguration : EntityTypeConfiguration<GES_ReglementFacture>
    {
        public GES_ReglementFactureConfiguration()
        {
            ToTable("GES_ReglementFacture");
            HasKey(x => x.ReglementFactureId);


            /***********************************/
            //    virtual public Societe ReglementSociete { get; set; }
            //virtual public Fichetiers ReglementFichetier { get; set; }
            
        }
        }
}
