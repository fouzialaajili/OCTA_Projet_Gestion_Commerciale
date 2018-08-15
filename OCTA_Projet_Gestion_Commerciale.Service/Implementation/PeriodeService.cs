
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;

using OCTA_Projet_Gestion_Commerciale.Data.Repositories;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class PeriodeService : IPeriodeService
    {
        private readonly IPeriodeRepository periodeRepository;


        private readonly IUnitOfWork unitOfWork;

        public PeriodeService(IPeriodeRepository periodeRepository, IUnitOfWork unitOfWork)
        {
            this.periodeRepository = periodeRepository;
            this.unitOfWork = unitOfWork;
        }



        public void CreatePeriodes(PeriodePivot Periodes)
        {
            GES_Periode item = Mapper.Map<PeriodePivot, GES_Periode>(Periodes);
            periodeRepository.Add(item);
        }

        public void DeletePeriode(PeriodePivot Periodes)
        {
           periodeRepository.Delete(Periodes.PeriodeId,Mapper.Map<PeriodePivot, GES_Periode>(Periodes));
        }

        public IEnumerable<PeriodePivot> GetALL()
        {
            IEnumerable<GES_Periode> periode = periodeRepository.GetAll().ToList();
            IEnumerable<PeriodePivot> periodePivots = Mapper.Map<IEnumerable<GES_Periode>, IEnumerable<PeriodePivot>>(periode);
            return periodePivots;
        }

        public PeriodePivot GetPeriodes(long id)
        {
            var item = periodeRepository.GetById((int)id);
            PeriodePivot periodePivot = Mapper.Map<GES_Periode, PeriodePivot>(item);
            return periodePivot;
        }

        public IEnumerable<PeriodePivot> GetPeriodesByName(string identifged)
        {
            IEnumerable<GES_Periode> periode = periodeRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<PeriodePivot> periodePivots = Mapper.Map<IEnumerable<GES_Periode>, IEnumerable<PeriodePivot>>(periode);
            return periodePivots;
        }

        public void SavePeriode()
        {
            unitOfWork.Commit();
        }

        public void UpdatePeriode(PeriodePivot Periodes)
        {
            periodeRepository.Update(Mapper.Map<PeriodePivot, GES_Periode>(Periodes));
        }
    }
}
