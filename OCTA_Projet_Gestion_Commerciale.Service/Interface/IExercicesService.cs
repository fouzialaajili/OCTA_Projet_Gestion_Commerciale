using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
  public  interface IExercicesService
    {
        IEnumerable<ExercicesPivot> GetALL();
        ExercicesPivot GetExercices(long? id);
        void DeletExercicesPivot(ExercicesPivot Exercices);
        void UpdateExercicesPivot(ExercicesPivot Exercices);
        void CreateExercicesPivot(ExercicesPivot Exercices);
        void SaveExercicesPivot();
    }
}
