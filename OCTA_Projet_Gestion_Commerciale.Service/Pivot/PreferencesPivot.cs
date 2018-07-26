
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class PreferencesPivot
    {
        public long Id { get; set; }


        public string IdUsers { get; set; }

        public long IdDossier { get; set; }

        public long IdExercices { get; set; }

        public DossiersPivot GEN_Dossiers { get; set; }

        public ExercicesPivot GEN_Exercices { get; set; }
    }
}
