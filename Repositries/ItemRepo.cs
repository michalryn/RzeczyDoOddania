using RzeczyDoOddania.Interfaces;
using RzeczyDoOddania.Data;
using RzeczyDoOddania.Models;

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
    }
}
