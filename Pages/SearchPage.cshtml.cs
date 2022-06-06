using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RzeczyDoOddania.Models;
using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.ViewModels.Item;

namespace RzeczyDoOddania.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly ISearchService _searchService;
        public SearchPageModel(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public IList<ItemForSearch> Items { get; set; }
        public async Task OnGet()
        {
            Items = await _searchService.GetItems();
        }
    }
}
