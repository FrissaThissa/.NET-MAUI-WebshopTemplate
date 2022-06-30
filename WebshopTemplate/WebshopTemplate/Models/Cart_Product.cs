using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTemplate.Models
{
    public class Cart_Product
    {
        public Product Product { get; private set; }
        public int Amount { get; private set; }

        public Cart_Product(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }

        public void ChangeAmount(int amount)
        {
            Amount = amount;
        }
    }
}
