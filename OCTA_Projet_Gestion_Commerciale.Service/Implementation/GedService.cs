
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
    class GedService : IGedService
    {
   

    private readonly IGedRepository gedRepository;


       private readonly IUnitOfWork unitOfWork;

       public GedService(IGedRepository gedRepository,  IUnitOfWork unitOfWork)
       {
           this.gedRepository = gedRepository;

           this.unitOfWork = unitOfWork;
       }

       public void CreateGed(GedPivot ged)
       {
           GES_Ged item = Mapper.Map<GedPivot, GES_Ged>(ged);
           gedRepository.Add(item);
       }

       public void DeleteGed(GedPivot ged)
       {
          // gedRepository.Delete(Mapper.Map<GedPivot, GES_Ged>(ged));
       }

       public IEnumerable<GedPivot> GetALL()
       {
           IEnumerable<GES_Ged> ged = gedRepository.GetAll().ToList();
           IEnumerable<GedPivot> geds = Mapper.Map<IEnumerable<GES_Ged>, IEnumerable<GedPivot>>(ged);
           return geds;
       }

       public IEnumerable<GedPivot> GetGed(string identifged)
       {
           IEnumerable<GES_Ged> geds = gedRepository.GetItemsByModelLibelle(identifged).ToList();
           IEnumerable<GedPivot> gedPivots = Mapper.Map<IEnumerable<GES_Ged>, IEnumerable<GedPivot>>(geds);
           return gedPivots;
       }

       public GedPivot GetGed(long id)
       {
           var item = gedRepository.GetById((int)id);
          GedPivot gedPivot = Mapper.Map<GES_Ged, GedPivot>(item);
           return gedPivot;
       }

       public void SaveGed()
       {

           unitOfWork.Commit();
       }

       public void UpdateGed(GedPivot ged)
       {
           gedRepository.Update(Mapper.Map<GedPivot, GES_Ged>(ged));
       }   

    }

}
