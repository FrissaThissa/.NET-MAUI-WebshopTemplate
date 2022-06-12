using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;
using Microsoft.Data.SqlClient;

namespace WebshopTemplate.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IDataService _dataService;

        public CategoryService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetHeadCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT * FROM Categories WHERE parentcategoryid IS NULL";
            SqlDataReader reader = _dataService.ExecuteReader(query);
            while (reader.Read())
            {
                Category category = new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader["Name"].ToString()
                };
                categories.Add(category);
            }
            reader.Close();
            return categories;
        }
    }
}
