using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using RzeczyDoOddania.Interfaces;

namespace RzeczyDoOddania.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly ISearchService _searchService;
        public SearchPageModel(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public IList<Item> Items { get; set; }
        public string imageData { get; set; }
        public async Task OnGet()
        {
            Items = await _searchService.GetItems();
            string imageBase64Data = Convert.ToBase64String(Items[0].Image);
            imageData = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
        }
    }
}
