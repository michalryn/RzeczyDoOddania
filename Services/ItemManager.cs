using Microsoft.AspNetCore.Identity;
using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.Models;
using RzeczyDoOddania.ViewModels.Item;

namespace RzeczyDoOddania.Services
{
    public class ItemManager : IItemManager
    {
        private readonly IItemRepo _itemRepo;
        public ItemManager(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }

        public ItemPageVM GetItemPageVM(int? id)
        {
            var item = _itemRepo.GetItem(id);
            if(item == null)
                return null;
            var imageList = ImagesToList(item.Images);
            var categories = item.Categories?.ToList();
            var users = item.InterestedUsers?.ToList();
            var iterestUsersCount = users?.Count();

            var itemVM = new ItemPageVM
            {
                Name = item.Name,
                Address = item.Address,
                Description = item.Description,
                Date = item.Date,
                Owner = item.Owner,
                Images = imageList,
                Categories = categories,
                Completed = item.Completed,
                ReservedFor = item.ReservedFor,
                InterestedUsers = users,
                InterestUsersCount = iterestUsersCount
            };

            return itemVM;
        }

        public void RegisterInterest(int? id, ApplicationUser user)
        {
            _itemRepo.AddInterestedUser(id, user);
        }

        public void UnRegisterInterest(int? id, ApplicationUser user)
        {
            _itemRepo.RemoveInterestedUser(id, user);
        }

        public void SaveItem(Item item)
        {
            _itemRepo.SaveItem(item);
        }

        private List<string> ImagesToList(ICollection<Image>? images)
        {
            var imageList = new List<string>();
            foreach (var image in images)
            {
                string imageBase64Data = Convert.ToBase64String(image.Data);
                var imagedata = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                imageList.Add(imagedata);
            }
            return imageList;
        }

        public Item GetItemNoRelations(int? id)
        {
            return _itemRepo.GetItemNoRelations(id);
        }
    }
}
