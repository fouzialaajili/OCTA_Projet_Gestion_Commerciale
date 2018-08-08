
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
    public class MotifService : IMotifService
    {
        private readonly IMotifRepository motifRepository;


        private readonly IUnitOfWork unitOfWork;

        public MotifService(IMotifRepository motifRepository, IUnitOfWork unitOfWork)
        {
            this.motifRepository = motifRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateMotif(MotifPivot Motifs)
        {
            GES_Motif item = Mapper.Map<MotifPivot, GES_Motif>(Motifs);
            motifRepository.Add(item);
        }

        public void DeleteMotif(MotifPivot Motifs)
        {
            motifRepository.Delete(Motifs.MotifdossierId,Mapper.Map<MotifPivot, GES_Motif>(Motifs));
        }

        public IEnumerable<MotifPivot> GetALL()
        {
            IEnumerable<GES_Motif> motif = motifRepository.GetAll().ToList();
            IEnumerable<MotifPivot> motifPivots = Mapper.Map<IEnumerable<GES_Motif>, IEnumerable<MotifPivot>>(motif);
            return motifPivots;
        }

        public MotifPivot GetMotif(long id)
        {
            var item = motifRepository.GetById((int)id);
            MotifPivot motifPivot = Mapper.Map<GES_Motif, MotifPivot>(item);
            return motifPivot;
        }

      

        public IEnumerable<MotifPivot> GetMotifsByName(string identifged)
        {
            IEnumerable<GES_Motif> motif = motifRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<MotifPivot> motifsPivots = Mapper.Map<IEnumerable<GES_Motif>, IEnumerable<MotifPivot>>(motif);
            return motifsPivots;
        }

        public void SaveMotif()
        {
            unitOfWork.Commit();
        }

        public void UpdateMotif(MotifPivot Motifs)
        {
            motifRepository.Update(Mapper.Map<MotifPivot, GES_Motif>(Motifs));
        }
    }
}
