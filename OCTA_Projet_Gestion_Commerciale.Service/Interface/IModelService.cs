using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IModelService
    {

        IEnumerable<ModelPivot> GetModelByIdDossier(long id);
        IEnumerable<ModelPivot> GetModels();
        IEnumerable<ModelPivot> GetModelIdDossier();
    }
}
