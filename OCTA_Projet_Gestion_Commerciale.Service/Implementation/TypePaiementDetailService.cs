using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    class TypePaiementDetailService : ITypePaiementDetailService
    {
        private readonly ITypePaiementDetailRepositoy typePaiementDetailRepository;


        private readonly IUnitOfWork unitOfWork;

        public TypePaiementDetailService(ITypePaiementDetailRepositoy typePaiementDetailRepository, IUnitOfWork unitOfWork)
        {
            this.typePaiementDetailRepository = typePaiementDetailRepository;
            this.unitOfWork = unitOfWork;
        }


        public void CreateTypePaiementDetail(TypePaiementDetailPivot TypePaiementDetail)
        {
            GEN_TypePaiementDetail item = Mapper.Map<TypePaiementDetailPivot, GEN_TypePaiementDetail>(TypePaiementDetail);
            typePaiementDetailRepository.Add(item);
        }

        public void DeleteTypePaiementDetail(TypePaiementDetailPivot TypePaiementDetail)
        {

            typePaiementDetailRepository.Delete(Mapper.Map<TypePaiementDetailPivot, GEN_TypePaiementDetail>(TypePaiementDetail));
        }

        public IEnumerable<TypePaiementDetailPivot> GetALL()
        {
            IEnumerable<GEN_TypePaiementDetail> typePaiementDetail= typePaiementDetailRepository.GetAll().ToList();
            IEnumerable<TypePaiementDetailPivot> typePaiementDetailPivots = Mapper.Map<IEnumerable<GEN_TypePaiementDetail>, IEnumerable<TypePaiementDetailPivot>>(typePaiementDetail);
            return typePaiementDetailPivots;
        }

        public TypePaiementDetailPivot GetTypePaiementDetails(long id)
        {
            var item = typePaiementDetailRepository.GetById((int)id);
            TypePaiementDetailPivot typePaiementDetailRepositoryPivot = Mapper.Map<GEN_TypePaiementDetail, TypePaiementDetailPivot>(item);
            return typePaiementDetailRepositoryPivot;
        }

        public void SaveTypePaiementDetail()
        {
            unitOfWork.Commit();
        }

       public IEnumerable<TypePaiementDetailPivot> GetTypePaiementDetailsByName(string identifged)
        {
          

            IEnumerable<GEN_TypePaiementDetail> typePaiementDetail = typePaiementDetailRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<TypePaiementDetailPivot> typePaiementDetailPivots = Mapper.Map<IEnumerable<GEN_TypePaiementDetail>, IEnumerable<TypePaiementDetailPivot>>(typePaiementDetail);
            return typePaiementDetailPivots;
        }

        public void UpdateTypePaiementDetail(TypePaiementDetailPivot TypePaiementDetail)
        {
            typePaiementDetailRepository.Update(Mapper.Map<TypePaiementDetailPivot, GEN_TypePaiementDetail>(TypePaiementDetail));
        }
    }
}
