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
using System.Windows.Input;

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
            Categories = _categoryService.GetHeadCategories().Result.ToList();
        }

        public Command OnCategoryClicked
             => new Command(async (object category) => await _navigationService.NavigateToProductOverview((Category)category));
    }
}
