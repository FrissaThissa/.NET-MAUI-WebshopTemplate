using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductDetailViewModel : ViewModelBase
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IWishlistService _wishlistService;

        public Product Product { get; private set; }

        public ProductDetailViewModel(IProductService productService, ICartService cartService, IWishlistService wishlistService)
        {
            _productService = productService;
            _cartService = cartService;
            _wishlistService = wishlistService;
        }

        public Command OnAddToCart
            => new Command((object product) => _cartService.AddProduct((Product)product));

        public Command OnAddToWishlist
            => new Command((object product) => _wishlistService.AddProduct((Product)product));

        public override Task OnNavigatingTo(object parameter)
        {
            if (parameter is null)
                Product = null;
            else
                Product = (Product)parameter;
            base.OnPropertyChanged("Product");
            return base.OnNavigatingTo(parameter);
        }
    }
}
