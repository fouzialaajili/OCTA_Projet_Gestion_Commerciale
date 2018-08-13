
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
    public class UniteService : IUniteService
    {


        private readonly IUniteRepository uniteRepository;


        private readonly IUnitOfWork unitOfWork;

        public UniteService(IUniteRepository uniteRepository, IUnitOfWork unitOfWork)
        {
            this.uniteRepository = uniteRepository;
            this.unitOfWork = unitOfWork;
        }


        public void CreateUnitePivot(UnitePivot doclieart)
        {
            GES_Unite  item = Mapper.Map<UnitePivot, GES_Unite>(doclieart);
            uniteRepository.Add(item);
        }

        public void DeleteUnitePivot(UnitePivot doclieart)
        {
            uniteRepository.Delete(doclieart.Id,Mapper.Map<UnitePivot, GES_Unite>(doclieart));
        }

        public IEnumerable<UnitePivot> GetALL()
        {
            IEnumerable<GES_Unite> unite = uniteRepository.GetAll().ToList();
            IEnumerable<UnitePivot> unitePivots = Mapper.Map<IEnumerable<GES_Unite>, IEnumerable<UnitePivot>>(unite);
            return unitePivots;
        }

        public UnitePivot GetUnitePivot(long id)
        {
            var item = uniteRepository.GetById((int)id);
            UnitePivot unitePivot = Mapper.Map<GES_Unite, UnitePivot>(item);
            return unitePivot;
        }

        public IEnumerable<UnitePivot> GetUnitePivotsByName(string UniteName)
        {
            IEnumerable<GES_Unite> unite = uniteRepository.GetItemsByModelLibelle(UniteName).ToList();
            IEnumerable<UnitePivot> unitePivots = Mapper.Map<IEnumerable<GES_Unite>, IEnumerable<UnitePivot>>(unite);
            return unitePivots;
        }

        public void SaveUnitePivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateUnitePivot(UnitePivot doclieart)
        {
            uniteRepository.Update(Mapper.Map<UnitePivot, GES_Unite>(doclieart));
        }
    }
}
