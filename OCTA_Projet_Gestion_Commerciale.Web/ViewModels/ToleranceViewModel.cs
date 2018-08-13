using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ToleranceViewModel
    {
        public long Id { get; set; }
        public int ToleranceEntier { get; set; }

        public long? ToleranceSocieteId { get; set; }
    }
}