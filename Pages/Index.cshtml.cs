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
        [Required(ErrorMessage = "Wybierz kategorię")]
        public int? SelectedCategorie { get; set; }
        public SelectList Options { get; set; }

        public void OnGet()
        {
            var options = _registerItem.GetOptions();
            Options = new SelectList(options, "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                var img = ms.ToArray();

                ms.Close();
                ms.Dispose();
                Item.Image = img;
            }

            if (SelectedCategorie != null)
            {
                var select = int.Parse(SelectedCategorie.ToString());
                var option = await _registerItem.GetCategory(select);
                Item.Category = option;
            }

            if (ModelState.IsValid)
            {
                Item.Date = DateTime.Now.AddDays(30);
                Item.UserName = "NotLoggedIn";
                _registerItem.RegisterItem(Item);
            }

            var options = _registerItem.GetOptions();
            Options = new SelectList(options, "Value", "Text");
            return Page();
        }
    }
}