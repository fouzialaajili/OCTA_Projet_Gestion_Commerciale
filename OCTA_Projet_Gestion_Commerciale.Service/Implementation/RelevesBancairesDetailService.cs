using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
  public  class RelevesBancairesDetailService : IRelevesBancairesDetailService
    {

        private readonly IRelevesBancairesDetailRepository RelevesBancairesdetailRepository;
        private readonly IUnitOfWork unitOfWork;

        public RelevesBancairesDetailService(IRelevesBancairesDetailRepository RelevesBancairesdetailRepository, IUnitOfWork unitOfWork)
        {
            this.RelevesBancairesdetailRepository = RelevesBancairesdetailRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateRelevesBancairesPivot(RelevesBancairesDetailPivot RelevesBancaires)
        {
            CPT_RelevesBancairesDetail clas = Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetail>(RelevesBancaires);
            RelevesBancairesdetailRepository.Add(clas);
        }

        public void DeletRelevesBancairesPivot(RelevesBancairesDetailPivot RelevesBancaires)
        {
            RelevesBancairesdetailRepository.Delete(RelevesBancaires.Id, Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetail>(RelevesBancaires));
        }

        public IEnumerable<RelevesBancairesDetailPivot> GetALL()
        {
            IEnumerable<CPT_RelevesBancairesDetail> comptes = RelevesBancairesdetailRepository.GetAll().ToList();
            IEnumerable<RelevesBancairesDetailPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_RelevesBancairesDetail>, IEnumerable<RelevesBancairesDetailPivot>>(comptes);
            return comptesPivots;
        }

        public RelevesBancairesDetailPivot GetRelevesBancaires(long? id)
        {
            var compteg = RelevesBancairesdetailRepository.GetById((int)id);
            RelevesBancairesDetailPivot comptegPivot = Mapper.Map<CPT_RelevesBancairesDetail, RelevesBancairesDetailPivot>(compteg);
            return comptegPivot;
        }

        public void SaveRelevesBancairesPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateRelevesBancairesPivot(RelevesBancairesDetailPivot RelevesBancaires)
        {
            RelevesBancairesdetailRepository.Update(RelevesBancaires.Id, Mapper.Map<RelevesBancairesDetailPivot, CPT_RelevesBancairesDetail>(RelevesBancaires));
        }
    }
}
