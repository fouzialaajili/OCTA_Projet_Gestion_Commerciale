namespace Store.Model
{
    using System;
    using System.Collections.Generic;
 

    public partial class CPT_PlanAnalytique
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Libelle { get; set; }

        public long? IdPlanAnalytique { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
    }
}
