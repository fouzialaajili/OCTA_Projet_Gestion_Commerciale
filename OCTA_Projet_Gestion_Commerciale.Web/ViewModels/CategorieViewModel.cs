using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class CategorieViewModel
    {
        public long CategorieId { get; set; }
        public string CategorieLibelle { get; set; }
        public string CategorieDescription
        { get; set; }
        public int CategorieSysuser { get; set; }
        public DateTime CategorieSysDateCreation { get; set; }
        public DateTime CategorieSysDateUpdate { get; set; }
        public bool CategorieActif { get; set; }
        public long? CategorieSocieteId { get; set; }
    }
}