using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.ViewModels.Item;
using Microsoft.AspNetCore.Identity;

namespace RzeczyDoOddania.Pages
{
    public class ItemPageModel : PageModel
    {
        private readonly IItemManager _itemManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public ItemPageModel(IItemManager itemManager, UserManager<ApplicationUser> userManager)
        {
            _itemManager = itemManager;
            _userManager = userManager;
        }
        public ItemPageVM Item;

        [BindProperty]
        public bool IsInterested { get; set; }

        public ApplicationUser? CurrentUser { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            CurrentUser = await _userManager.GetUserAsync(User);


            if (id == null)
            {
                return NotFound();
            }

            Item = _itemManager.GetItem(id);

            if (Item == null)
            {
                return NotFound();
            }

            var interest = Item.InterestedUsers?.Any(i => i.Id == CurrentUser.Id);
            if (interest != null && interest == true)
            {
                IsInterested = true;
            }
            else
                IsInterested = false;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CurrentUser = await _userManager.GetUserAsync(User);

            if(IsInterested)
            {
               _itemManager.RegisterInterest(id, CurrentUser);
            }
            else
            {
                _itemManager.UnRegisterInterest(id, CurrentUser);
            }

            return RedirectToPage();
        }
    }
}
