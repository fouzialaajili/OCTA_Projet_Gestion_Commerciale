using OCTA_Projet_Gestion_Commerciale.Data.Infrastructure;
using OCTA_Projet_Gestion_Commerciale.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCTA_Projet_Gestion_Commerciale.Model;
using System.Linq.Expressions;
using OCTA_Projet_Gestion_Commerciale.Service.Interface;
using OCTA_Projet_Gestion_Commerciale.Service.Pivot;
using AutoMapper;

namespace OCTA_Projet_Gestion_Commerciale.Service.Implementation
{
 public   class ItemsService : IItemsService
    {
        private readonly IItemsRepository itemsRepository;
        private readonly IUnitOfWork unitOfWork;

        public  ItemsService(IItemsRepository itemsRepository, IUnitOfWork unitOfWork)
        {
            this.itemsRepository = itemsRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateItemsPivot(ItemsPivot items)
        {
            GEN_Items item = Mapper.Map<ItemsPivot, GEN_Items>(items);
            itemsRepository.Add(item);
        }

        public void DeleteItemsPivot(ItemsPivot items)
        {
            itemsRepository.Delete(items.Id,Mapper.Map<ItemsPivot, GEN_Items>(items));
        }

        public IEnumerable<ItemsPivot> GetAllItems()
        {
            IEnumerable<GEN_Items> items = itemsRepository.GetAll().ToList();
            IEnumerable<ItemsPivot> itemsPivots = Mapper.Map<IEnumerable<GEN_Items>, IEnumerable<ItemsPivot>>(items);
            return itemsPivots;
        }

        public ItemsPivot GetItems(long? id)
        {
            var item = itemsRepository.GetById((int)id);
            ItemsPivot itemPivot = Mapper.Map<GEN_Items, ItemsPivot>(item);
            return itemPivot;
        }

        public void SaveItemsPivot()
        {
            unitOfWork.Commit();
        }

        public void UpdateItemsPivot(ItemsPivot items)
        {
            itemsRepository.Update(Mapper.Map<ItemsPivot, GEN_Items>(items));
        }
    }
}
