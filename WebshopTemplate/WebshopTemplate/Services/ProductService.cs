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
    public class ProductService : IProductService
    {
        public ProductService()
        {

        }

        public async Task<List<Product>> GetAllProducts()
        {
            HttpClient client = new HttpClient();
            string responsejson = await client.GetStringAsync("https://localhost:7075/api/products").ConfigureAwait(false);
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(responsejson);
            return result;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductsByCategory(Category category)
        {
            HttpClient client = new HttpClient();
            string responsejson = await client.GetStringAsync($"https://localhost:7075/api/products?categoryid={category.Id}").ConfigureAwait(false);
            List<Product> result = JsonConvert.DeserializeObject<List<Product>>(responsejson);
            return result;
        }
    }
}
