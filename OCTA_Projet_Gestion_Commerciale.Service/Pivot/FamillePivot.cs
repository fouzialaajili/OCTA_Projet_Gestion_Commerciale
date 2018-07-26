using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Pivot
{
    public class FamillePivot
    {
        public long FamilleId { get; set; }
        public int FamilleCode { get; set; }
        public int FamilleLibelle { get; set; }
public int FamilleSyuser { get; set; }
        public DateTime FamilleSysDateCreation { get; set; }
        public DateTime FamilleSysDateUpdate { get; set; }
        public long  FamilleSocieteId { get; set; }
        public  DossiersPivot FamilleSociete { get; set; }
    }
}
