
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    interface ITicketDetailService
    {
        IEnumerable<TicketDetailPivot> GetALL();
        TicketDetailPivot GetTicketDetail(long id);
        IEnumerable<TicketDetailPivot> GetTicketDetailsByName(string identifged);
        void DeleteTicketDetail(TicketDetailPivot TicketDetail);
        void UpdateTicketDetail(TicketDetailPivot TicketDetail);
        void CreateTicketDetail(TicketDetailPivot TicketDetail);
        void SaveTicketDetail();


    }
}
