using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Services
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepo _itemRepo;
        public ItemManager(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public Item GetItem(int? id)
        {
            return _itemRepo.GetItem(id);
        }
    }
}
