using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Interfaces
{
    public interface ISearchService
    {
        Task<IList<Item>> GetItems();
    }
}
