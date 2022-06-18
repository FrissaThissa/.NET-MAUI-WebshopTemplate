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
        public List<Category> GetHeadCategories();
        public List<Category> GetSubCategories(Category category);
    }
}
