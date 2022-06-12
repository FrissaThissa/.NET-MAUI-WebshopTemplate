using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;
using Microsoft.Data.SqlClient;

namespace WebshopTemplate.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataService _dataService;

        public ProductService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Products";
            SqlDataReader reader = _dataService.ExecuteReader(query);
            while (reader.Read())
            {
                Product product = new Product
                {
                    Name = reader["Name"].ToString()
                };
                products.Add(product);
            }
            reader.Close();
            return products;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(Category category)
        {
            List<Product> products = new List<Product>();
            string query = $"SELECT * FROM Products WHERE CategoryId = {category.Id}";
            SqlDataReader reader = _dataService.ExecuteReader(query);
            while (reader.Read())
            {
                Product product = new Product
                {
                    Name = reader["Name"].ToString()
                };
                products.Add(product);
            }
            reader.Close();
            return products;
        }
    }
}
