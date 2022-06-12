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
        
        public IList<ItemForSearchVM> Items { get; set; }
        public async Task OnGet(string name)
        {
            string? SearchString = name;
            if(SearchString == null)
            {
                Items = await _searchService.GetItems();
            }
            else
            {
                Items = await _searchService.GetItemsSearch(SearchString);
            }
            

                
        }
    }
}
