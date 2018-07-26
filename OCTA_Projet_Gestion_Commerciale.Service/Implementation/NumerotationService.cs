
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
    class NumerotationService : INumerotationService
    {


        private readonly INumerotationRepository numerotationRepository;


        private readonly IUnitOfWork unitOfWork;

        public NumerotationService(INumerotationRepository numerotationRepository, IUnitOfWork unitOfWork)
        {
            this.numerotationRepository = numerotationRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateNumerotation(NumerotationPivot numerotation)
        {

            GES_Numerotation item = Mapper.Map<NumerotationPivot, GES_Numerotation>(numerotation);
            numerotationRepository.Add(item);
        }

        public void DeleteNumerotation(NumerotationPivot numerotation)
        {
            numerotationRepository.Delete(Mapper.Map<NumerotationPivot, GES_Numerotation>(numerotation));
        }

        public IEnumerable<NumerotationPivot> GetALL()
        {
            IEnumerable<GES_Numerotation> numerotation= numerotationRepository.GetAll().ToList();
            IEnumerable<NumerotationPivot> numerotationPivots = Mapper.Map<IEnumerable<GES_Numerotation>, IEnumerable<NumerotationPivot>>(numerotation);
            return numerotationPivots;
        }

        public NumerotationPivot GetNumerotation(long id)
        {
            var item = numerotationRepository.GetById((int)id);
            NumerotationPivot numerotationPivot = Mapper.Map<GES_Numerotation, NumerotationPivot>(item);
            return numerotationPivot;
        }

        public IEnumerable<NumerotationPivot> GetNumerotationsByName(string identifged)
        {
            IEnumerable<GES_Numerotation> numerotation = numerotationRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<NumerotationPivot> numerotationPivots = Mapper.Map<IEnumerable<GES_Numerotation>, IEnumerable<NumerotationPivot>>(numerotation);
            return numerotationPivots;
        }

        public void SaveMotif()
        {
            unitOfWork.Commit();
        }

        public void UpdateNumerotation(NumerotationPivot numerotation)
        {
            numerotationRepository.Update(Mapper.Map<NumerotationPivot, GES_Numerotation>(numerotation));
        }
    }
}
