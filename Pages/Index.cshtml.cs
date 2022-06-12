using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using Microsoft.EntityFrameworkCore;
using RzeczyDoOddania.Data;
using RzeczyDoOddania.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;


namespace RzeczyDoOddania.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IItemRepo _itemRepo;
        private readonly IRegisterItemService _registerItem;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IItemRepo itemRepo, IRegisterItemService registerItem)
        {
            _logger = logger;
            _itemRepo = itemRepo;
            _registerItem = registerItem;
        }
        [BindProperty]
        public int? SelectedCategory { get; set; }
        public SelectList Options { get; set; }
        public IActionResult OnPost()
        {
            if ((SearchString != null) && (SelectedCategory != null))
            {
                return RedirectToPage("/SearchPage", new { name = SearchString, cid= SelectedCategory});
            }
            if ((SearchString == null)&& (SelectedCategory != null))
            {
                return RedirectToPage("/SearchPage", new { cid = SelectedCategory });
            }
            if ((SearchString != null) && (SelectedCategory == null))
            {
                return RedirectToPage("/SearchPage", new { name = SearchString });
            }
            return RedirectToPage("/SearchPage");

        }

        public void OnGet()
        {
            var options = _registerItem.GetOptions();
            Options = new SelectList(options, "Value", "Text");
        }
    }
}