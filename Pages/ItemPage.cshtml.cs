using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using RzeczyDoOddania.Interfaces;

namespace RzeczyDoOddania.Pages
{
    public class ItemPageModel : PageModel
    {
        private readonly IItemManager _itemManager;
        public ItemPageModel(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }
        public Item Item;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Item = _itemManager.GetItem(id);

            if(Item == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
