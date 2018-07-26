
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IMotifService
    {
        IEnumerable<MotifPivot> GetALL();
        MotifPivot GetMotif(long id);
        IEnumerable<MotifPivot> GetMotifsByName(string identifged);
        void DeleteMotif(MotifPivot Motif);
        void UpdateMotif(MotifPivot Motif);
        void CreateMotif(MotifPivot Motif);
        void SaveMotif();
    }
}
