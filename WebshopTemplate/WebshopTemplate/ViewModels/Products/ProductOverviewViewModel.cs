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

        public Category Category { get; private set; }
        public List<Category> SubCategories { get; private set; }
        public List<Product> Products { get; private set; }


        public ProductOverviewViewModel(INavigationService navigationService, IProductService productService, ICategoryService categoryService)
        {
            _navigationService = navigationService;
            _productService = productService;
            _categoryService = categoryService;
            Products = new List<Product>();
        }

        public Command OnProductClicked
            => new Command(async (object product) => await _navigationService.NavigateToProductDetail((Product) product));

        public Command OnSubCategoryClicked
            => new Command(async (object category) => await _navigationService.NavigateToProductOverview((Category)category));

        public override Task OnNavigatingTo(object parameter)
        {
            if (parameter is null)
            {
                Products = _productService.GetAllProducts().Result.ToList();
                SubCategories = _categoryService.GetHeadCategories().Result.ToList();
            }
            else
            {
                this.Category = (Category)parameter;
                Products = _productService.GetProductsByCategory(this.Category).Result.ToList();
                SubCategories = _categoryService.GetSubCategories(this.Category).Result.ToList();
            }
            base.OnPropertyChanged("Products");
            base.OnPropertyChanged("SubCategories");
            return base.OnNavigatingTo(parameter);
        }
    }
}
