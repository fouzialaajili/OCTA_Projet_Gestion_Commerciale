
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
   public interface ITiersService
    {
        //IEnumerable<TiersPivot> GetALL();
        IEnumerable<TiersPivot> GetALL();
        TiersPivot GetTiers();
        TiersPivot GetTier(long? id );
        IEnumerable<TiersPivot> GetTiersByName(string identifged);
        void DeleteTiers(TiersPivot Tiers);
        void UpdateTiers(TiersPivot Tiers);
        void CreateTiers(TiersPivot Tiers);
        IEnumerable<TiersPivot> GetTiersByItems_TypeTiers(string Type);
        void SaveTiers();
    }
}
