using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddania.Data;
using RzeczyDoOddania.Interfaces;

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
        public Item Item { get; set; }
        [BindProperty]
        public int[] SelectedCategories { get; set; }
        public MultiSelectList Options { get; set; }
        public string result { get; set; }
        public List<SelectListItem> GetOptions()
        {
            return _registerItem.GetCategories().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
        public void OnGet()
        {
            var options = GetOptions();
            Options = new MultiSelectList(options, "Value", "Text");
        }

        public IActionResult OnPost(List<string> SelectedCategories)
        {
            if(SelectedCategories.Count > 0)
            {
                foreach(var category in SelectedCategories)
                {
                    result += category;
                }
            }

            var options = GetOptions();
            Options = new MultiSelectList(options, "Value", "Text");
            return Page();
        }
    }
}