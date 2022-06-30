using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface IWishlistService
    {
        public void AddProduct(Product product);
        public void RemoveProduct(Product product);
        public Wishlist GetWishlist();
    }
}
