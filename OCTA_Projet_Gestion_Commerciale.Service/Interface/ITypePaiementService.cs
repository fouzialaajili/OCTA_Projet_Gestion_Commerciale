
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface ITypePaiementService
    {
        IEnumerable<TypePaiementPivot> GetALL();
        TypePaiementPivot GetTypePaiement(long id);
        IEnumerable<TypePaiementPivot> GetTypePaiementsByName(string identifged);
        void DeleteTypePaiement(TypePaiementPivot TypePaiement);
        void UpdateTypePaiement(TypePaiementPivot TypePaiement);
        void CreateTypePaiement(TypePaiementPivot TypePaiement);
        void SaveTypePaiement();
    }
}
