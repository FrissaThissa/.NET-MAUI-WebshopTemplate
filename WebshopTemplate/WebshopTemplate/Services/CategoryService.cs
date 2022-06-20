using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace WebshopTemplate.Services
{
    internal class CategoryService : ICategoryService
    {
        public CategoryService()
        {
            
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetHeadCategories()
        {
            HttpClient client = new HttpClient();
            string responsejson = await client.GetStringAsync("https://localhost:7075/api/categories/head").ConfigureAwait(false);
            List<Category> result = JsonConvert.DeserializeObject<List<Category>>(responsejson);
            return result;
        }

        public async Task<List<Category>> GetSubCategories(Category category)
        {
            HttpClient client = new HttpClient();
            string responsejson = await client.GetStringAsync($"https://localhost:7075/api/categories?parentcategoryid={category.Id}").ConfigureAwait(false);
            List<Category> result = JsonConvert.DeserializeObject<List<Category>>(responsejson);
            return result;
        }
    }
}
