﻿using Microsoft.AspNetCore.Mvc;
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

namespace RzeczyDoOddania.Pages
{
    [Authorize]
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
        [Display(Name = "Wybierz kategorie")]
        [Required, MinLength(1, ErrorMessage = "Wybierz kategorię")]
        public IEnumerable<string>? SelectedCategories { get; set; }
        public MultiSelectList Options { get; set; }

        [BindProperty]
        [Required, MinLength(1, ErrorMessage = "Dodaj zdjęcie")]
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