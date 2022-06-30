using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public class CartService : ICartService
    {
        public Cart Cart { get; private set; }

        public CartService()
        {
            Cart = new Cart();
        }

        public void AddProduct(Product product)
        {
            Cart.AddProduct(product);
        }

        public void AddProduct(Product product, int amount)
        {
            Cart.AddProduct(product, amount);
        }

        public void RemoveProduct(Cart_Product product)
        {
            Cart.RemoveProduct(product);
        }

        public Cart GetCart()
        {
            return Cart;
        }
    }
}
