using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTemplate.Models
{
    public class Wishlist
    {
        public ObservableCollection<Product> Products { get; private set; }

        public Wishlist()
        {
            Products = new ObservableCollection<Product>();
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
