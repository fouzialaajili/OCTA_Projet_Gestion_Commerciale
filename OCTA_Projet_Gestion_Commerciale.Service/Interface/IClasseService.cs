using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
 public interface IClasseService
    {
        IEnumerable<ClassePivot> GetALL();
        ClassePivot GetClasse(long? id);
        void DeleteClassePivot(ClassePivot classe);
        void UpdateClassePivot(ClassePivot classe);
        void CreateClassePivot(ClassePivot classe);
        void SaveClassePivot();
    }
}
