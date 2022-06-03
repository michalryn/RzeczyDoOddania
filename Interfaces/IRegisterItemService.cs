using Microsoft.AspNetCore.Mvc.Rendering;
using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Interfaces
{
    public interface IRegisterItemService
    {
        void RegisterItem(Item item);
        IList<Category> GetCategories();
        Task<Category> GetCategory(int id);
        List<SelectListItem> GetOptions();

    }
}
