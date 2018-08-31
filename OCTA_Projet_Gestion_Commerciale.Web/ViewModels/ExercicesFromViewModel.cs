using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ExercicesFromViewModel
    {
        public long Id { get; set; }


        public string CodeExercice { get; set; }

        public string Libelle { get; set; }


        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public bool Actif { get; set; }

        public int? ComptaCloture { get; set; }

        public int? GescomCloture { get; set; }

        public int? PaieCloture { get; set; }

        public long? IdDossier { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
        public GEN_Dossiers_Form_ViewModel GEN_Dossiers { get; set; }


        public ICollection<PeriodesFormViewModel> GEN_Periodes { get; set; }


        public ICollection<PreferencesFormViewModel> GEN_Preferences { get; set; }
    }
}