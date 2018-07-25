using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Model
{
   
 public class GES_Impression
    {
      public long ImpressionId { get; set; }
      public long? ImpressionType { get; set; }
      public string ImpressionChemin { get; set; }
      public string ImpressionLogo { get; set; }
     /***/ public long? ImpressionSocieteId { get; set; }
        public  virtual GEN_Dossiers ImpressionSociete { get; set; }


    }
}
