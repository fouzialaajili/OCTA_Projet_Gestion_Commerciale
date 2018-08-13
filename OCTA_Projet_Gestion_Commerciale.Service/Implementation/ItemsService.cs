using AutoMapper;
using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using OCTA_Projet_Gestion_Commerciale.Model;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
   public  class ItemsService : IItemsService
    {
        private readonly IItemsRepository itemsRepository;
         
        private readonly IUnitOfWork unitOfWork;

        public ItemsService(IItemsRepository itemsRepository, IUnitOfWork unitOfWork)
        {
            this.itemsRepository = itemsRepository;
            this.unitOfWork = unitOfWork;
        }

        public ItemsPivot GetItems(long? id)
        {
            id = 1;
            var item = itemsRepository.GetById((int)id);
            ItemsPivot itemPivot = Mapper.Map<GEN_Items, ItemsPivot>(item);
            return itemPivot;
        }

        public IEnumerable<ItemsPivot> GetItemsByModel(string model)
        {
            IEnumerable<GEN_Items> item = itemsRepository.GetItemsByModel(model).ToList();
            IEnumerable<ItemsPivot> itemPivots = Mapper.Map<IEnumerable<GEN_Items>, IEnumerable<ItemsPivot>>(item);
            return itemPivots;
        }

        public IEnumerable<ItemsPivot> GetItemsByModelAndActif(string type)
        {
            IEnumerable<GEN_Items> item = itemsRepository.GetItemsByModelAndType(type).ToList();
            IEnumerable<ItemsPivot> itemPivots = Mapper.Map<IEnumerable<GEN_Items>, IEnumerable<ItemsPivot>>(item);
            return itemPivots;
        }
    }
}
