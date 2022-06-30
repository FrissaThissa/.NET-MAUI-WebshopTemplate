using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public class WishlistService : IWishlistService
    {
        public Wishlist Wishlist { get; private set; }

        public WishlistService()
        {
            Wishlist = new Wishlist();
        }

        public void AddProduct(Product product)
        {
            Wishlist.AddProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            Wishlist.RemoveProduct(product);
        }

        public Wishlist GetWishlist()
        {
            return Wishlist;
        }
    }
}
