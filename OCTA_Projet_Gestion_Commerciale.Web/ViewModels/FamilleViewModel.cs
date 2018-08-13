using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class FamilleViewModel
    {
        public long FamilleId { get; set; }
        public int FamilleCode { get; set; }
        public int FamilleLibelle { get; set; }
        public int FamilleSyuser { get; set; }
        public DateTime FamilleSysDateCreation { get; set; }
        public DateTime FamilleSysDateUpdate { get; set; }
        public long? FamilleSocieteId { get; set; }
    }
}