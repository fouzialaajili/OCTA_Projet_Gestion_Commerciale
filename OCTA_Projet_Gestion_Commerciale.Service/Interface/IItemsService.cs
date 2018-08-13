using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Interface
{
    public interface IItemsService
    {
        IEnumerable<ItemsPivot> GetItemsByModel(String model);
        IEnumerable<ItemsPivot> GetItemsByModelAndActif(String type);

     ItemsPivot GetItems(long? id);
        IEnumerable<ItemsPivot> GetAllItems();
       
        void DeleteItemsPivot(ItemsPivot items);
        void UpdateItemsPivot(ItemsPivot items);
        void CreateItemsPivot(ItemsPivot items);
        void SaveItemsPivot();
    }
}



