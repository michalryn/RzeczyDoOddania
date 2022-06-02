using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Interfaces
{
    public interface ICategoryRepo
    {
        IQueryable<Category> GetAll();
    }
}
