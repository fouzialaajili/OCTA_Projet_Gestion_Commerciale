using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class RelevesBancairesService : IRelevesBancairesService
    {

        private readonly IRelevesBancairesRepository RelevesBancairesRepository;
        private readonly IUnitOfWork unitOfWork;

        public RelevesBancairesService(IRelevesBancairesRepository RelevesBancairesRepository, IUnitOfWork unitOfWork)
        {
            this.RelevesBancairesRepository = RelevesBancairesRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateRelevesBancairesPivot(RelevesBancairesPivot RelevesBancaires)
        {
            CPT_RelevesBancaires clas = Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancaires>(RelevesBancaires);
            RelevesBancairesRepository.Add(clas);
        }

        public void DeletRelevesBancairesPivot(RelevesBancairesPivot RelevesBancaires)
        {
            RelevesBancairesRepository.Delete(RelevesBancaires.Id, Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancaires>(RelevesBancaires));
        }

        public IEnumerable<RelevesBancairesPivot> GetALL()
        {
            IEnumerable<CPT_RelevesBancaires> comptes = RelevesBancairesRepository.GetAll().ToList();
            IEnumerable<RelevesBancairesPivot> comptesPivots = Mapper.Map<IEnumerable<CPT_RelevesBancaires>, IEnumerable<RelevesBancairesPivot>>(comptes);
            return comptesPivots;
        }

        public RelevesBancairesPivot GetRelevesBancaires(long? id)
        {
            var compteg =RelevesBancairesRepository.GetById((int)id);
            RelevesBancairesPivot comptegPivot = Mapper.Map<CPT_RelevesBancaires, RelevesBancairesPivot>(compteg);
            return comptegPivot;
        }

        public void SaveRelevesBancairesPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateRelevesBancairesPivot(RelevesBancairesPivot RelevesBancaires)
        {
            RelevesBancairesRepository.Update(RelevesBancaires.Id, Mapper.Map<RelevesBancairesPivot, CPT_RelevesBancaires>(RelevesBancaires));
        }
    }
}
