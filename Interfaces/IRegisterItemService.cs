using Microsoft.AspNetCore.Mvc.Rendering;
using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Interfaces
{
    public interface IRegisterItemService
    {
        void RegisterItem(Item item);
        public IList<Category> GetCategories();
        public List<SelectListItem> GetOptions();
    }
}
