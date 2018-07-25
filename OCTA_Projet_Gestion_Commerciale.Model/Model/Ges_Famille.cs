using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    public class GES_Famille
    {
        public long FamilleId { get; set; }
        public int FamilleCode { get; set; }
        public int FamilleLibelle { get; set; }
public int FamilleSyuser { get; set; }
        public DateTime FamilleSysDateCreation { get; set; }
        public DateTime FamilleSysDateUpdate { get; set; }
        public long  FamilleSocieteId { get; set; }
        public virtual GEN_Dossiers FamilleSociete { get; set; }
    }
}
