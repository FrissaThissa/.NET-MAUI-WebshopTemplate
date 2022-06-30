using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Models;
using WebshopTemplate.Services;

namespace WebshopTemplate.ViewModels.Products
{
    public class ProductOverviewViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        private readonly IWishlistService _wishlistService;

        public Category Category { get; private set; }
        public List<Category> SubCategories { get; private set; }
        public List<Product> Products { get; private set; }


        public ProductOverviewViewModel(INavigationService navigationService, IProductService productService, ICategoryService categoryService, ICartService cartService, IWishlistService wishlistService)
        {
            _navigationService = navigationService;
            _productService = productService;
            _categoryService = categoryService;
            _cartService = cartService;
            _wishlistService = wishlistService;
            Products = new List<Product>();
        }

        public Command OnProductClicked
            => new Command(async (object product) => await _navigationService.NavigateToProductDetail((Product) product));

        public Command OnSubCategoryClicked
            => new Command(async (object category) => await _navigationService.NavigateToProductOverview((Category)category));


        public Command OnCartClicked
            => new Command(async () => await _navigationService.NavigateToCart());

        public Command OnWishlistClicked
            => new Command(async () => await _navigationService.NavigateToWishlist());

        public Command OnAddToCart
            => new Command((object product) => _cartService.AddProduct((Product)product));

        public Command OnAddToWishlist
            => new Command((object product) => _wishlistService.AddProduct((Product)product));

        public override Task OnNavigatingTo(object parameter)
        {
            if (parameter is null)
            {
                Products = _productService.GetAllProducts().Result.ToList();
                SubCategories = _categoryService.GetHeadCategories().Result.ToList();
            }
            else
            {
                if(parameter.GetType() == typeof(Models.Category))
                {
                    this.Category = (Category)parameter;
                    Products = _productService.GetProductsByCategory(this.Category).Result.ToList();
                    SubCategories = _categoryService.GetSubCategories(this.Category).Result.ToList();
                }
                else
                {
                    Products = _productService.GetProductsBySearchInput((string)parameter).Result.ToList();
                }
            }
            base.OnPropertyChanged("Products");
            base.OnPropertyChanged("SubCategories");
            return base.OnNavigatingTo(parameter);
        }
    }
}
