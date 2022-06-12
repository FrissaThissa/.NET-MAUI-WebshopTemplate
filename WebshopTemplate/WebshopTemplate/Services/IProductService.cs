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
        public List<Product> GetAllProducts();
        public List<Product> GetProductsByCategory(Category category);
    }
}
