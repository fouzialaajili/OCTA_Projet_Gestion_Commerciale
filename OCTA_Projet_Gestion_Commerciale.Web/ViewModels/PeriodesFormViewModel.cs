using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class PeriodesFormViewModel
    {
        public long Id { get; set; }

        public string Libelle { get; set; }

        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public bool? Actif { get; set; }

        public int ComptaCloture { get; set; }

        public int? GescomCloture { get; set; }

        public int? PaieCloture { get; set; }

        public long? IdExercice { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }

    }
}