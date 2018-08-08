using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCTA_Projet_Gestion_Commerciale.Web.ViewModels
{
    public class ImpressionFromViewModel
    {
        public long Id { get; set; }
        public long? ImpressionType { get; set; }
        public string ImpressionChemin { get; set; }
        public string ImpressionLogo { get; set; }
        /***/
        public long? ImpressionSocieteId { get; set; }
    }
}