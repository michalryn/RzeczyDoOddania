using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Interfaces
{
    public interface IItemRepo
    {
        void AddItem(Item item);
        IQueryable<Item> GetItems();
        Item GetItem(int? id);
        void AddInterestedUser(int? id, ApplicationUser interestedUser);
        void RemoveInterestedUser(int? id, ApplicationUser interestedUser);
    }
}
