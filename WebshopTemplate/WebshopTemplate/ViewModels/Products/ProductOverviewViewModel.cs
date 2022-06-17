﻿using System;
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

        public List<Product> Products { get; private set; }

        public ProductOverviewViewModel(INavigationService navigationService, IProductService productService)
        {
            _navigationService = navigationService;
            _productService = productService;
            Products = new List<Product>();
        }

        public Command OnProductClicked
            => new Command(async (object product) => await _navigationService.NavigateToProductDetail((Product) product));
        
        public override Task OnNavigatingTo(object parameter)
        {
            if (parameter is null)
                Products = _productService.GetAllProducts();
            else
                Products = _productService.GetProductsByCategory((Category)parameter);
            base.OnPropertyChanged("Products");
            return base.OnNavigatingTo(parameter);
        }
    }
}
