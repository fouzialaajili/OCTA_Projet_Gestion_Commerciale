using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class NumerotationFormViewModel
    {
        public long NumerotationId { get; set; }
        public long? NumerotationType { get; set; }
        public string NumerotationExpression { get; set; }
        public int NumerotationNombre { get; set; }
        public string NumerotationValeur { get; set; }
        public int NumerotationCompteur { get; set; }
        public int NumerotationIncrement { get; set; }

        public long? NumerotationSysuser { get; set; }
        public DateTime? NumerotationSysDateCreation { get; set; }
        public DateTime? NumerotationSysDateUpdate { get; set; }


        public long? NumerotationDossierId { get; set; }
    }
}