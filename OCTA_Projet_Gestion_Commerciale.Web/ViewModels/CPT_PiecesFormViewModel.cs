using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CPT_PiecesFormViewModel
    {

        public long Id { get; set; }

        public long? TypePiece { get; set; }

        public string OriginePiece { get; set; }

        public DateTime? DatePiece { get; set; }

        public DateTime? DateReference { get; set; }

        public DateTime? DateFacture { get; set; }

        public string RefPiece { get; set; }

        public long? IdTiers { get; set; }

        public long? IdJournal { get; set; }


        public string NumPiece { get; set; }

        public string Libelle { get; set; }

        public double? CourChange { get; set; }

        public long? IdDeviseTC { get; set; }


        public long? IdDeviseTR { get; set; }


        public long? IdDossier { get; set; }

        public long? IdDossierSite { get; set; }


        public int? Brouillon { get; set; }

        public string sys_user { get; set; }

        public DateTime? sys_dateUpdate { get; set; }

        public DateTime? sys_dateCreation { get; set; }
    }
}