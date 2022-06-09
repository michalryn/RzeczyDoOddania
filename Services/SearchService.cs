using RzeczyDoOddania.Models;
using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.ViewModels.Item;

namespace RzeczyDoOddania.Services
{
    public class SearchService : ISearchService
    {
        private readonly IItemRepo _itemRepo;

        public SearchService(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }
        public async Task<IList<ItemForSearch>> GetItems()
        {
            var items = _itemRepo.GetItems();
            var itemForSearchList = new List<ItemForSearch>();
            foreach (var item in items)
            {
                var images = item.Images.ToList();
                string imageBase64Data = Convert.ToBase64String(images[0].Data);
                var imagedata = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                itemForSearchList.Add(new ItemForSearch
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Date = item.Date,
                    Image = imagedata
                });
            }
            return itemForSearchList;
        }
    }
}
