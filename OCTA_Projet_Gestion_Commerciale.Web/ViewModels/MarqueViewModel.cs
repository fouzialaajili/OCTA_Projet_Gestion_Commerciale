using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class MarqueViewModel
    {
        public long Id { get; set; }
        public string MarqueCode { get; set; }
        public string MarqueLibelle { get; set; }
        public bool MarqueActif { get; set; }
        public int MarqueSys_user { get; set; }
        public DateTime MarqueSys_DateCreation { get; set; }
        public DateTime MarqueSys_DateUpdate { get; set; }
        public long? MarqueSocieteId { get; set; }
    }
}