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
                var count = item.InterestedUsers?.Count();
                var interestUsersCount = count == 0 ? 0 : count;

                itemForSearchList.Add(new ItemForSearchVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Categories = item.Categories?.ToList(),
                    Date = item.Date,
                    Image = imagedata,
                    ReservedFor = item.ReservedFor,
                    InterestUsersCount = interestUsersCount
                });
            }
            return itemForSearchList;
        }
        public async Task<IList<ItemForSearchVM>> GetItemsSearch(string? search)
        {
            var items = _itemRepo.GetItemsSearch(search);
            var itemForSearchList = new List<ItemForSearchVM>();
            foreach (var item in items)
            {
                var images = item.Images.ToList();
                string imageBase64Data = Convert.ToBase64String(images[0].Data);
                var imagedata = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                var count = item.InterestedUsers?.Count();
                var interestUsersCount = count == 0 ? 0 : count;

                itemForSearchList.Add(new ItemForSearchVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Categories = item.Categories?.ToList(),
                    Date = item.Date,
                    Image = imagedata,
                    ReservedFor = item.ReservedFor,
                    InterestUsersCount = interestUsersCount
                });
            }
            return itemForSearchList;
        }
        public async Task<IList<ItemForSearchVM>> GetCategoriesSearch(int? id)
        {
            var items = _itemRepo.GetCategoriesSearch(id);
            var itemForSearchList = new List<ItemForSearchVM>();
            foreach (var item in items)
            {
                var images = item.Images.ToList();
                string imageBase64Data = Convert.ToBase64String(images[0].Data);
                var imagedata = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                var count = item.InterestedUsers?.Count();
                var interestUsersCount = count == 0 ? 0 : count;

                itemForSearchList.Add(new ItemForSearchVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Categories = item.Categories?.ToList(),
                    Date = item.Date,
                    Image = imagedata,
                    ReservedFor = item.ReservedFor,
                    InterestUsersCount = interestUsersCount
                });
            }
            return itemForSearchList;
        }
        public async Task<IList<ItemForSearchVM>> GetBoth(string? search, int? id)
        {
            var items = _itemRepo.GetBoth(search, id);
            var itemForSearchList = new List<ItemForSearchVM>();
            foreach (var item in items)
            {
                var images = item.Images.ToList();
                string imageBase64Data = Convert.ToBase64String(images[0].Data);
                var imagedata = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                var count = item.InterestedUsers?.Count();
                var interestUsersCount = count == 0 ? 0 : count;

                itemForSearchList.Add(new ItemForSearchVM
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Categories = item.Categories?.ToList(),
                    Date = item.Date,
                    Image = imagedata,
                    ReservedFor = item.ReservedFor,
                    InterestUsersCount = interestUsersCount
                });
            }
            return itemForSearchList;
        }
    }
}
