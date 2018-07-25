using OCTA_Projet_Gestion_Commerciale.Data.Configuration;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data
{
  public  class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities") { }

        public DbSet<GES_Admin> Admins { get; set; }
        public DbSet<GES_Licence> Licences { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GES_AdminConfiguration());
            modelBuilder.Configurations.Add(new GES_LicenceConfiguration());

        }
    }
}
