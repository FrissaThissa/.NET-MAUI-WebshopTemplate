using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTemplate.Models
{
    public class Wishlist
    {
        public List<Product> Products { get; private set; }

        public Wishlist()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (!Products.Contains(product))
                Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (!Products.Contains(product))
                return;

            Products.Remove(product);
        }
    }
}
