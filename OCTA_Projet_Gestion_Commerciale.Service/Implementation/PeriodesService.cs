using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
    public class PeriodesService : IPeriodesService
    {

        private readonly IPeriodesRepository periodeRepository;


        private readonly IUnitOfWork unitOfWork;

        public PeriodesService(IPeriodesRepository periodeRepository, IUnitOfWork unitOfWork)
        {
            this.periodeRepository = periodeRepository;
            this.unitOfWork = unitOfWork;
        }





        public void CreatePeriodes(PeriodesPivot Periodes)
        {
            GEN_Periodes item = Mapper.Map<PeriodesPivot, GEN_Periodes>(Periodes);
            periodeRepository.Add(item);
        }

        public void DeletePeriodes(PeriodesPivot Periodes)
        {
            periodeRepository.Delete(Periodes.Id, Mapper.Map<PeriodesPivot, GEN_Periodes>(Periodes));
        }

        public IEnumerable<PeriodesPivot> GetALL()
        {
            IEnumerable<GEN_Periodes> periode = periodeRepository.GetAll().ToList();
            IEnumerable<PeriodesPivot> periodePivots = Mapper.Map<IEnumerable<GEN_Periodes>, IEnumerable<PeriodesPivot>>(periode);
            return periodePivots;
        }

        public PeriodesPivot GetPeriodes(long id)
        {
            var item = periodeRepository.GetById((int)id);
            PeriodesPivot periodePivot = Mapper.Map<GEN_Periodes, PeriodesPivot>(item);
            return periodePivot;
        }


        public void SavePeriodes()
        {
            unitOfWork.Commit();
        }

        public void UpdatePeriodes(PeriodesPivot Periodes)
        {
            periodeRepository.Update(Mapper.Map<PeriodesPivot, GEN_Periodes>(Periodes));
        }
    }
}
