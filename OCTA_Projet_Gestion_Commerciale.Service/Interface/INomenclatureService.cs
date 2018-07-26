
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface INomenclatureService
    {

        IEnumerable<NomenclaturePivot> GetALL();
        NomenclaturePivot GetNomenclatures(long id);
        IEnumerable<NomenclaturePivot> GetNomenclaturesByName(string identifged);
        void DeleteNomenclature(NomenclaturePivot nomenclature);
        void UpdateNomenclature(NomenclaturePivot nomenclature);
        void CreateNomenclature(NomenclaturePivot nomenclature);
        void SaveMotif();
    }
}
