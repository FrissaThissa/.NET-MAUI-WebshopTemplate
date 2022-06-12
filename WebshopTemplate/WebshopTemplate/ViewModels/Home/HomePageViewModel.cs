using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Services;
using WebshopTemplate.Models;
using WebshopTemplate.Views.Products;
using WebshopTemplate.ViewModels.Products;
using System.Diagnostics;

namespace WebshopTemplate.ViewModels.Home
{
    public partial class HomePageViewModel : ViewModelBase
    {
        private readonly ICategoryService _categoryService;
        private readonly INavigationService _navigationService;

        public List<Category> Categories { get; private set; }

        public HomePageViewModel(ICategoryService categoryService, INavigationService navigationService)
        {
            _categoryService = categoryService;
            _navigationService = navigationService;
            Categories = _categoryService.GetHeadCategories();
        }

        public Command OnCategoryClicked(Category category)
            => new Command(async () => await _navigationService.NavigateToProductIndex(category));
    }
}
