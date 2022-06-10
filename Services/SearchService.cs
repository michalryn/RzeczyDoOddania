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
        public async Task<IList<ItemForSearchVM>> GetItems()
        {
            var items = _itemRepo.GetItems();
            var itemForSearchList = new List<ItemForSearchVM>();
            foreach (var item in items)
            {
                var images = item.Images.ToList();
                string imageBase64Data = Convert.ToBase64String(images[0].Data);
                var imagedata = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                
                itemForSearchList.Add(new ItemForSearchVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Categories = item.Categories?.ToList(),
                    Date = item.Date,
                    Image = imagedata,
                    ReservedFor = item.ReservedFor,
                    InterestUsersCount = item.InterestedUsers?.Count()
                });
            }
            return itemForSearchList;
        }
    }
}
