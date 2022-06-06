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
            _itemRepo.AddItem(item);
        }

        public IList<Category> GetCategories()
        {
            return _categoryRepo.GetAll().ToList();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _categoryRepo.GetCategory(id);
        }

        public List<SelectListItem> GetOptions()
        {
            var options = _categoryRepo.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return options;
        }
    }
}
