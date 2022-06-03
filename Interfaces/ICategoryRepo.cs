using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.Interfaces
{
    public interface ICategoryRepo
    {
        IQueryable<Category> GetAll();

        Task<Category> GetCategory(int id);
    }
}
