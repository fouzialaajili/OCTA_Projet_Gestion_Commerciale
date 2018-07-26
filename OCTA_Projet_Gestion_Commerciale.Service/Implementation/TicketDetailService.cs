
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation { 
    class TicketDetailService : ITicketDetailService
    {


        private readonly ITicketDetailRepository ticketDetailRepository;


        private readonly IUnitOfWork unitOfWork;

        public TicketDetailService(ITicketDetailRepository ticketDetailRepository, IUnitOfWork unitOfWork)
        {
            this.ticketDetailRepository = ticketDetailRepository;
            this.unitOfWork = unitOfWork;
        }




        public void CreateTicketDetail(TicketDetailPivot TicketDetail)
        {

            GES_TicketDetail item = Mapper.Map<TicketDetailPivot, GES_TicketDetail>(TicketDetail);
            ticketDetailRepository.Add(item);
        }

        public void DeleteTicketDetail(TicketDetailPivot TicketDetail)
        {
            ticketDetailRepository.Delete(Mapper.Map<TicketDetailPivot, GES_TicketDetail>(TicketDetail));
        }

        public IEnumerable<TicketDetailPivot> GetALL()
        {
            IEnumerable<GES_TicketDetail> ticketDetail = ticketDetailRepository.GetAll().ToList();
            IEnumerable<TicketDetailPivot> ticketDetailPivots = Mapper.Map<IEnumerable<GES_TicketDetail>, IEnumerable<TicketDetailPivot>>(ticketDetail);
            return ticketDetailPivots;
        }

        public TicketDetailPivot GetTicketDetail(long id)
        {
            var item = ticketDetailRepository.GetById((int)id);
            TicketDetailPivot ticketDetailPivots = Mapper.Map<GES_TicketDetail, TicketDetailPivot>(item);
            return ticketDetailPivots;
        }

        public void SaveTicketDetail()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<TicketDetailPivot> GetTicketDetailsByName(string identifged)
        {
            IEnumerable<GES_TicketDetail> ticketDetail = ticketDetailRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<TicketDetailPivot> TicketDetailPivots = Mapper.Map<IEnumerable<GES_TicketDetail>, IEnumerable<TicketDetailPivot>>(ticketDetail);
            return TicketDetailPivots;
        }

        public void UpdateTicketDetail(TicketDetailPivot TicketDetail)
        {
            ticketDetailRepository.Update(Mapper.Map<TicketDetailPivot, GES_TicketDetail>(TicketDetail));
        }
    }
}
