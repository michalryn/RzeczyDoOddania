using RzeczyDoOddania.Models;
using RzeczyDoOddania.Interfaces;

namespace RzeczyDoOddania.Services
{
    public class SearchService : ISearchService
    {
        private readonly IItemRepo _itemRepo;

        public SearchService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<IList<Item>> GetItems()
        {
            var items = await _itemRepo.GetItems();
            return items.ToList();
        }
    }
}
