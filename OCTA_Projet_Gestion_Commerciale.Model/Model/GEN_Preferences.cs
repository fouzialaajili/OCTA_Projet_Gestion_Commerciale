namespace Store.Model
{
    using System;
    using System.Collections.Generic;
   

    public partial class GEN_Preferences
    {
        public long Id { get; set; }

       
        public string IdUsers { get; set; }

        public long IdDossier { get; set; }

        public long IdExercices { get; set; }

        public virtual GEN_Dossiers GEN_Dossiers { get; set; }

        public virtual GEN_Exercices GEN_Exercices { get; set; }
       // public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
