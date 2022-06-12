using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.Data;
using RzeczyDoOddania.Models;
using Microsoft.EntityFrameworkCore;

namespace RzeczyDoOddania.Repositries
{
    public class ItemRepo : IItemRepo
    {
        private readonly ApplicationDbContext _context;

        public ItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public Item GetItem(int? id)
        {
            return _context.Items.Include(i => i.Images).Include(c => c.Categories).Include(u => u.InterestedUsers).Include(o => o.Owner).AsSplitQuery().FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<Item> GetItems()
        {
            return _context.Items.Include(c => c.Categories).Include(u => u.InterestedUsers).AsSplitQuery().Include(i => i.Images);
        }

        public void AddInterestedUser(int? id, ApplicationUser interestedUser)
        {
            var item = _context.Items.Include(u => u.InterestedUsers).FirstOrDefault(i => i.Id == id);
            item.InterestedUsers.Add(interestedUser);
            _context.SaveChanges();
        }
        public void RemoveInterestedUser(int? id, ApplicationUser interestedUser)
        {
            var item = _context.Items.Include(u => u.InterestedUsers).FirstOrDefault(i => i.Id == id);
            item.InterestedUsers.Remove(interestedUser);
            _context.SaveChanges();
        }
        
        public void SaveItem(Item item)
        {
            _context.Items.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Item GetItemNoRelations(int? id)
        {
            return _context.Items.Where(i => i.Id == id).FirstOrDefault();
        }
        public IQueryable<Item> GetItemsSearch(string? search)
        {
            return _context.Items.Where(i => i.Name.Contains(search) || i.Address.Contains(search)).Include(u => u.InterestedUsers).AsSplitQuery().Include(i => i.Images).Include(c => c.Categories);
        }
        public IQueryable<Item> GetCategoriesSearch(int? id)
        {
            return _context.Items.Include(c => c.Categories).Where(c => c.Categories.Any(i => i.Id == id)).Include(u => u.InterestedUsers).AsSplitQuery().Include(i => i.Images);
        }
        public IQueryable<Item> GetBoth(string? search, int? id)
        {
            return _context.Items.Include(c => c.Categories).Where(i =>(i.Name.Contains(search) || i.Address.Contains(search))&& i.Categories.Any(i => i.Id == id)).Include(u => u.InterestedUsers).AsSplitQuery().Include(i => i.Images);
        }                 
    }
}
