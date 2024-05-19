using BookStoreApp.DataAccess;
using BookStoreApp.Models;
using BookStorreApp.DataAccess.Repository.IRepository;

namespace BookStorreApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
