
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface IMotifTicketService
    {
        IEnumerable<MotifTicketPivot> GetALL();
        MotifTicketPivot GetMotifTickes(long id);
        IEnumerable<MotifTicketPivot> GetMotifTicketsByName(string identifged);
        void DeleteMotifTicket(MotifTicketPivot Motif);
        void UpdateMotifTicket(MotifTicketPivot Motif);
        void CreateMotifTicket(MotifTicketPivot Motif);
        void SaveMotif();
    }
}
