
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;


        private readonly IUnitOfWork unitOfWork;

        public TicketService(ITicketRepository ticketRepository, IUnitOfWork unitOfWork)
        {
            this.ticketRepository = ticketRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTicket(TicketPivot Tickets)
        {
            GES_Ticket item = Mapper.Map<TicketPivot, GES_Ticket>(Tickets);
            ticketRepository.Add(item);
        }

        public void DeleteTicket(TicketPivot Tickets)
        {
            //ticketRepository.Delete(Mapper.Map<TicketPivot, GES_Ticket>(Tickets));
        }

        public IEnumerable<TicketPivot> GetALL()
        {
            IEnumerable<GES_Ticket> ticket = ticketRepository.GetAll().ToList();

            IEnumerable<TicketPivot> ticketPivots = Mapper.Map<IEnumerable<GES_Ticket>, IEnumerable<TicketPivot>>(ticket);
            return ticketPivots;
        }

        public TicketPivot GetTickets(long id)
        {
            var item = ticketRepository.GetById((int)id);
           TicketPivot ticketPivots = Mapper.Map<GES_Ticket, TicketPivot>(item);
            return ticketPivots;
        }

        public void SaveTicket()
        {

            unitOfWork.Commit();
        }

        public IEnumerable<TicketPivot> GetTicketsById(string identifged)
        {
            IEnumerable<GES_Ticket> ticket = ticketRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<TicketPivot> ticketPivots = Mapper.Map<IEnumerable<GES_Ticket>, IEnumerable<TicketPivot>>(ticket);
            return ticketPivots;
        }

        public void UpdateTicket(TicketPivot Tickets)
        {
            ticketRepository.Update(Mapper.Map<TicketPivot, GES_Ticket>(Tickets));
        }
    }
}
