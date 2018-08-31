using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using OCTA_Projet_Gestion_Commerciale.Model;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
   public class PiecesService: IPiecesService
    {
        private readonly IPiecesRepository PiecesRepository;
        private readonly IUnitOfWork unitOfWork;

        public PiecesService(IPiecesRepository PiecesRepository, IUnitOfWork unitOfWork)
        {
            this.PiecesRepository = PiecesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePiecesPivot(PiecesPivot piecesPivot)
        {
            CPT_Pieces clas = Mapper.Map<PiecesPivot, CPT_Pieces>(piecesPivot);
            PiecesRepository.Add(clas);
        }

        public void DeletPiecesPivot(PiecesPivot piecesPivot)
        {
            PiecesRepository.Delete(piecesPivot.Id, Mapper.Map<PiecesPivot, CPT_Pieces>(piecesPivot));
        }

        public IEnumerable<PiecesPivot> GetALL()
        {
            IEnumerable<CPT_Pieces> Pieces = PiecesRepository.GetAll().ToList();
            IEnumerable<PiecesPivot> PiecesPivots = Mapper.Map<IEnumerable<CPT_Pieces>, IEnumerable<PiecesPivot>>(Pieces);
            return PiecesPivots;
        }

        public PiecesPivot GetPiecesPivot(long? id)
        {
            var Pieces = PiecesRepository.GetById((int)id);
            PiecesPivot PiecesPivot = Mapper.Map<CPT_Pieces, PiecesPivot>(Pieces);
            return PiecesPivot;
        }

        public void SavePiecesPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdatePiecesPivot(PiecesPivot piecesPivot)
        {
            PiecesRepository.Update(piecesPivot.Id, Mapper.Map<PiecesPivot, CPT_Pieces>(piecesPivot));
        }
    }
}
