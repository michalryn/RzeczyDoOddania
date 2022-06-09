using Microsoft.AspNetCore.Authorization;
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
        public RegisterItemModel(IRegisterItemService registerItem)
        {
            _registerItem = registerItem;
        }

        [BindProperty]
        public Item Item { get; set; }

        [BindProperty]
        [Display(Name = "Wybierz kategorie")]
        [Required, MinLength(1, ErrorMessage = "Wybierz kategori�")]
        public IEnumerable<string>? SelectedCategories { get; set; }
        public MultiSelectList Options { get; set; }

        [BindProperty]
        [Required, MinLength(1, ErrorMessage = "Dodaj zdj�cie")]
        [DataType(DataType.Upload)]
        public IFormFileCollection FormFiles { get; set; }

        public void OnGet()
        {
            var options = _registerItem.GetOptions();
            Options = new MultiSelectList(options, "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {
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
                Item.OwnerName = User.Identity.Name;
                _registerItem.RegisterItem(Item);
            }

            var options = _registerItem.GetOptions();
            Options = new MultiSelectList(options, "Value", "Text");
            return Page();
        }
    }
}

