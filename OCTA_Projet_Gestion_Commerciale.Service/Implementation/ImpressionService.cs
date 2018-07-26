
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

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class ImpressionService : IImpressionService
    {

        private readonly IImpressionRepositoy impressionRepository;


        private readonly IUnitOfWork unitOfWork;

        public ImpressionService(IImpressionRepositoy impressionRepository, IUnitOfWork unitOfWork)
        {
            this.impressionRepository = impressionRepository;

            this.unitOfWork = unitOfWork;
        }

        public void CreateImpression(ImpressionPivot impression)
        {
            GES_Impression item = Mapper.Map<ImpressionPivot, GES_Impression>(impression);
            impressionRepository.Add(item);
        }

        public void DeleteImpression(ImpressionPivot impression)
        {
            impressionRepository.Delete(Mapper.Map<ImpressionPivot, GES_Impression>(impression));
        }

        public IEnumerable<ImpressionPivot> GetALL()
        {
            IEnumerable<GES_Impression> impression = impressionRepository.GetAll().ToList();
            IEnumerable<ImpressionPivot> impressions = Mapper.Map<IEnumerable<GES_Impression>, IEnumerable<ImpressionPivot>>(impression);
            return impressions;
        }

        public ImpressionPivot GetImpression(long id)
        {
            var item = impressionRepository.GetById((int)id);
            ImpressionPivot impressionPivot = Mapper.Map<GES_Impression, ImpressionPivot>(item);
            return impressionPivot;
        }

        public IEnumerable<ImpressionPivot> Impressions(string identifged)
        {
            IEnumerable<GES_Impression> impression = impressionRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<ImpressionPivot> impressions = Mapper.Map<IEnumerable<GES_Impression>, IEnumerable<ImpressionPivot>>(impression);
            return impressions;
        }

        public void SaveImpression()
        {
            throw new NotImplementedException();
        }

        public void UpdateImpression(ImpressionPivot impression)
        {
            impressionRepository.Update(Mapper.Map<ImpressionPivot, GES_Impression>(impression));
        }
    }
}
