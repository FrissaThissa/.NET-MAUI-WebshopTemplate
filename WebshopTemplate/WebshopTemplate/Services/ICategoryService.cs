using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface ICategoryService
    {
        public Category GetCategoryById(int id);
        public List<Category> GetAllCategories();        
        public Task<List<Category>> GetHeadCategories();
        public Task<List<Category>> GetSubCategories(Category category);
    }
}
