using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTemplate.Models
{
    public class Cart
    {
        public ObservableCollection<Cart_Product> Products { get; private set; }

        public Cart()
        {
            Products = new ObservableCollection<Cart_Product>();
        }

        public void AddProduct(Product product)
        {
            Cart_Product productInCart = null;
            foreach(Cart_Product cart_Product in Products)
            {
                if(cart_Product.Product == product)
                {
                    productInCart = cart_Product;
                    break;
                }
            }

            if (productInCart != null)
                productInCart.ChangeAmount(productInCart.Amount + 1);
            else
                Products.Add(new Cart_Product(product, 1));
        }

        public void AddProduct(Product product, int amount)
        {
            Cart_Product productInCart = null;
            foreach (Cart_Product cart_Product in Products)
            {
                if (cart_Product.Product == product)
                {
                    productInCart = cart_Product;
                    break;
                }
            }

            if (productInCart != null)
                productInCart.ChangeAmount(productInCart.Amount + amount);
            else
                Products.Add(new Cart_Product(product, amount));
        }

        public void RemoveProduct(Cart_Product product)
        {
            Products.Remove(product);
        }
    }
}
