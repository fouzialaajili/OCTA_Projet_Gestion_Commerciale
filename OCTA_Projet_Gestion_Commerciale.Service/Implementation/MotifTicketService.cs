
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
    public class MotifTicketService : IMotifTicketService
    {
        private readonly IMotifTicketRepository motifTicketRepository;


        private readonly IUnitOfWork unitOfWork;

        public MotifTicketService(IMotifTicketRepository motifTicketRepository, IUnitOfWork unitOfWork)
        {
            this.motifTicketRepository = motifTicketRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateMotifTicket(MotifTicketPivot Motif)
        {
            GES_MotifTicket item = Mapper.Map<MotifTicketPivot, GES_MotifTicket>(Motif);
            motifTicketRepository.Add(item);
        }

        public void DeleteMotifTicket(MotifTicketPivot Motif)
        {
            motifTicketRepository.Delete(Motif.MotifIdticket,Mapper.Map<MotifTicketPivot, GES_MotifTicket>(Motif));
        }

        public IEnumerable<MotifTicketPivot> GetALL()
        {
            IEnumerable<GES_MotifTicket> motif = motifTicketRepository.GetAll().ToList();
            IEnumerable<MotifTicketPivot> motifPivots = Mapper.Map<IEnumerable<GES_MotifTicket>, IEnumerable<MotifTicketPivot>>(motif);
            return motifPivots;
        }

        public MotifTicketPivot GetMotifTickes(long id)
        {
            var item = motifTicketRepository.GetById((int)id);
            MotifTicketPivot  motifPivot = Mapper.Map<GES_MotifTicket, MotifTicketPivot>(item);
            return motifPivot;
        }

        public IEnumerable<MotifTicketPivot> GetMotifTicketsByName(string identifged)
        {
            IEnumerable<GES_MotifTicket> motif = motifTicketRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<MotifTicketPivot> motifsPivots = Mapper.Map<IEnumerable<GES_MotifTicket>, IEnumerable<MotifTicketPivot>>(motif);
            return motifsPivots;
        }

        public void SaveMotif()
        {
            unitOfWork.Commit();
        }

        public void UpdateMotifTicket(MotifTicketPivot Motif)
        {
            motifTicketRepository.Update(Mapper.Map<MotifTicketPivot, GES_MotifTicket>(Motif));
        }
    }
}
