
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IObjectifService
    {
        IEnumerable<ObjectifPivot> GetALL();
        ObjectifPivot GetObjectif(long id);
        //IEnumerable<ObjectifPivot> Objectifs(string identifged);
        void DeleteObjectif(ObjectifPivot objectif);
        void UpdateObjectif(ObjectifPivot objectif);
        void CreateObjectif(ObjectifPivot objectif);
        void SaveObjectif();

    }
}
