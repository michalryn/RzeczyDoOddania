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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IItemRepo itemRepo)
        {
            _logger = logger;
            _itemRepo = itemRepo;
        }
       
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/SearchPage", new { name = SearchString });
            }

            return Page();

        }

        public void OnGet()
        {

        }
    }
}