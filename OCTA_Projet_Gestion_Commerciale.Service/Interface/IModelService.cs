using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IModelService
    {
        IEnumerable<ModelPivot> GetModelByIdDossier(long id);
        IEnumerable<ModelPivot> GetALL();
        ModelPivot GetModel(long? id);
        IEnumerable<ModelPivot> GetMotifsByName(string identifged);
        void DeleteModel(ModelPivot Model);
        void UpdateModel(ModelPivot Model);
        void CreateModel(ModelPivot Model);
        void SaveModel();
    }
}
