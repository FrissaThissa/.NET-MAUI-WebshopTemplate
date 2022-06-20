using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IProductService
    {
        public Product GetProductById(int id);
        public Task<List<Product>> GetAllProducts();
        public Task<List<Product>> GetProductsByCategory(Category category);
    }
}
