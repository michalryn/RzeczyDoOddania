using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.Models;
using System.ComponentModel.DataAnnotations;

namespace RzeczyDoOddania.Pages
{
    [Authorize]
    public class RegisterItemModel : PageModel
    {
        private readonly IRegisterItemService _registerItem;
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterItemModel(IRegisterItemService registerItem, UserManager<ApplicationUser> userManager)
        {
            _registerItem = registerItem;
            _userManager = userManager;
        }

        [BindProperty]
        public Item Item { get; set; }

        [BindProperty]
        [Display(Name = "Wybierz kategorie")]
        [Required, MinLength(1, ErrorMessage = "Wybierz kategoriê")]
        public IEnumerable<string>? SelectedCategories { get; set; }
        public MultiSelectList Options { get; set; }

        [BindProperty]
        [Required, MinLength(1, ErrorMessage = "Dodaj zdjêcie")]
        [DataType(DataType.Upload)]
        public IFormFileCollection FormFiles { get; set; }

        public void OnGet()
        {
            var options = _registerItem.GetOptions();
            Options = new MultiSelectList(options, "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {
            if(SelectedCategories?.Count() == 0)
            {
                ModelState.AddModelError("SelectedCategories", "Wybierz kategoriê");
            }
            if (ModelState.IsValid)
            {
                Item.Images = new List<Image>();

                foreach (var file in FormFiles)
                {
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    var img = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                    var image = new Image { Data = img };
                    Item.Images.Add(image);
                }

                if (SelectedCategories != null)
                {
                    Item.Categories = new List<Category>();
                    foreach (var category in SelectedCategories)
                    {
                        var id = int.Parse(category.ToString());
                        var option = await _registerItem.GetCategory(id);
                        Item.Categories.Add(option);
                    }
                }
                Item.Date = DateTime.Now.AddDays(30);
                Item.Completed = false;
                Item.Owner = await _userManager.GetUserAsync(User);
                _registerItem.RegisterItem(Item);

                return RedirectToPage();
            }

            /*var options = _registerItem.GetOptions();
            Options = new MultiSelectList(options, "Value", "Text");
            return Page();*/
            return Page();
        }
    }
}

