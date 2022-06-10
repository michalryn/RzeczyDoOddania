using RzeczyDoOddania.Models;
using RzeczyDoOddania.ViewModels.Item;

namespace RzeczyDoOddania.Interfaces
{
    public interface IItemManager
    {
        ItemPageVM GetItem(int? id);
        void RegisterInterest(int? id, ApplicationUser user);
        void UnRegisterInterest(int? id, ApplicationUser user);
    }
}
