using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface ICartService
    {
        public void AddProduct(Product product);
        public void AddProduct(Product product, int amount);
        public void RemoveProduct(Cart_Product product);
        public Cart GetCart();
    }
}
