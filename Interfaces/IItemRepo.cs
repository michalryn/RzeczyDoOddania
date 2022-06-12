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
        void SaveItem(Item item);
        Item GetItemNoRelations(int? id);
        IQueryable<Item> GetItemsSearch(string? search);
        IQueryable<Item> GetCategoriesSearch(int? id);
        IQueryable<Item> GetBoth(string? search, int? id);
    }
}
