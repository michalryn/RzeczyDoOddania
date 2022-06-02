using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RzeczyDoOddania.Services
{
    public class RegisterItemService : IRegisterItemService
    {
        private readonly IItemRepo _itemRepo;
        private readonly ICategoryRepo _categoryRepo;

        public RegisterItemService(IItemRepo itemRepo, ICategoryRepo categoryRepo)
        {
            _itemRepo = itemRepo;
            _categoryRepo = categoryRepo;
        }

        public void RegisterItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));


        }

        public IList<Category> GetCategories()
        {
            return _categoryRepo.GetAll().ToList();
        }

        public List<SelectListItem> GetOptions()
        {
            return _categoryRepo.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}
