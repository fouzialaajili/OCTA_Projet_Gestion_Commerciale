using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface IPiecesService
    {
        IEnumerable<PiecesPivot> GetALL();
        PiecesPivot GetPiecesPivot(long? id);
        void DeletPiecesPivot(PiecesPivot piecesPivot);
        void UpdatePiecesPivot(PiecesPivot piecesPivot);
        void CreatePiecesPivot(PiecesPivot piecesPivot);
        void SavePiecesPivot();
    }
}
