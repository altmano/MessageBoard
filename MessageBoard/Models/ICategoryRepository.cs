using System.Collections.Generic;

namespace MessageBoard.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        public Category GetCategoryById(int id);    
    }
}
