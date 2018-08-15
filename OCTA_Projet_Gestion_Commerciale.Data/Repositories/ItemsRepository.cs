using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Utils;
using OCTA_Projet_Gestion_Commerciale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Data.Repositories
{
    public interface IItemsRepository : IRepository<GEN_Items>
    {
        IEnumerable<GEN_Items> GetItemsByModel(String model);
        IEnumerable<GEN_Items> GetItemsByModelAndType(String type);
    }
    public class ItemsRepository : RepositoryBase<GEN_Items>, IItemsRepository
    {
        public ItemsRepository(IDbFactory dbFactory) : base(dbFactory) { }

     
        public IEnumerable<GEN_Items> GetItemsByModel(String model)
        {
            var items = this.DbContext.GEN_Items.Where(e => e.GEN_Model.Model == model && e.GEN_Model.IdDossier == Constantes.CurrentPreferenceIdDossier);

            return items;
        }
       public  IEnumerable<GEN_Items> GetItemsByModelAndType( String type)
        {
            var items = this.DbContext.GEN_Items.Where(e => e.GEN_Model.Model == "NatureTiers" && (e.Valeur== type || type == "") && e.GEN_Model.IdDossier == Constantes.CurrentPreferenceIdDossier);

            return items;
           
        }

     
    } }
