using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddania.Data;
using RzeczyDoOddania.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RzeczyDoOddania.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRegisterItemService _registerItem;

        public IndexModel(ILogger<IndexModel> logger, IRegisterItemService registerItem)
        {
            _logger = logger;
            _registerItem = registerItem;
        }
        [BindProperty]
        public Item Item { get; set; }

        [BindProperty]
        public int SelectedCategorie { get; set; }
        public SelectList Options { get; set; }

        public void OnGet()
        {
            var options = _registerItem.GetOptions();
            Options = new SelectList(options, "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {
            var option = await _registerItem.GetCategory(SelectedCategorie);
            Item.Category = option;
            Item.Date = DateTime.Now.AddDays(30);
            Item.UserName = "NotLoggedIn";
            Item.Image = new byte[] { 0 };

            if (ModelState.IsValid)
            {
                _registerItem.RegisterItem(Item);
                return Page();
            }

            var options = _registerItem.GetOptions();
            Options = new SelectList(options, "Value", "Text");
            return Page();
        }
    }
}