
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface ITicketService
    {
        IEnumerable<TicketPivot> GetALL();
        TicketPivot GetTickets(long id);
        IEnumerable<TicketPivot> GetTicketsById(string identifged);
        void DeleteTicket(TicketPivot Tickets);
        void UpdateTicket(TicketPivot Tickets);
        void CreateTicket(TicketPivot Tickets);
        void SaveTicket();
    }
}
