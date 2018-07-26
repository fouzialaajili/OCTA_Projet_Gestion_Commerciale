﻿using System;
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
    class TypePaiementService : ITypePaiementService
    {
        private readonly ITypePaiementRepositoy typePaiementRepository;


        private readonly IUnitOfWork unitOfWork;

        public TypePaiementService(ITypePaiementRepositoy typePaiementRepository, IUnitOfWork unitOfWork)
        {
            this.typePaiementRepository = typePaiementRepository;
            this.unitOfWork = unitOfWork;
        }


        public void CreateTypePaiement(TypePaiementPivot TypePaiement)
        {
            GEN_TypePaiement  item = Mapper.Map<TypePaiementPivot, GEN_TypePaiement>(TypePaiement);
            typePaiementRepository.Add(item);
        }

        public void DeleteTypePaiement(TypePaiementPivot TypePaiement)
        {
            typePaiementRepository.Delete(Mapper.Map<TypePaiementPivot, GEN_TypePaiement>(TypePaiement));
        }

        public IEnumerable<TypePaiementPivot> GetALL()
        {
            IEnumerable<GEN_TypePaiement> motif = typePaiementRepository.GetAll().ToList();
            IEnumerable<TypePaiementPivot> motifPivots = Mapper.Map<IEnumerable<GEN_TypePaiement>, IEnumerable<TypePaiementPivot>>(motif);
            return motifPivots;
        }

        public TypePaiementPivot GetTypePaiement(long id)
        {
            var item = typePaiementRepository.GetById((int)id);
            TypePaiementPivot  motifPivot = Mapper.Map<GEN_TypePaiement, TypePaiementPivot>(item);
            return motifPivot;
        }

        public void SaveTypePaiement()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<TypePaiementPivot> GetTypePaiementsByName(string identifged)
        {
            IEnumerable<GEN_TypePaiement> typePaiement = typePaiementRepository.GetItemsByModelLibelle(identifged).ToList();
            IEnumerable<TypePaiementPivot> typePaiementPivots = Mapper.Map<IEnumerable<GEN_TypePaiement>, IEnumerable<TypePaiementPivot>>(typePaiement);
            return typePaiementPivots;
        }

        public void UpdateTypePaiement(TypePaiementPivot TypePaiement)
        {
            typePaiementRepository.Update(Mapper.Map<TypePaiementPivot, GEN_TypePaiement>(TypePaiement));
        }
    }
}
