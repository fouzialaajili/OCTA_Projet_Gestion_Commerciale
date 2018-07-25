namespace Store.Model
{
    using System;
    using System.Collections.Generic;
  

    public partial class GEN_Numeration
    {
       
        public long Id { get; set; }

        public string Objet { get; set; }

        public long? idDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }
    }
}
