using System.Collections.Generic;
using System.Linq;

namespace MessageBoard.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _appDbContext.Categories;
        }

        public Category GetCategoryById(int id)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
