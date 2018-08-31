using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class PreferencesViewModel
    {
        public long Id { get; set; }


        public string IdUsers { get; set; }

        public long IdDossier { get; set; }

        public long IdExercices { get; set; }
        //public GEN_Dossiers_ViewModel GEN_Dossiers { get; set; }

        //public ExercicesViewModel GEN_Exercices { get; set; }
    }
}