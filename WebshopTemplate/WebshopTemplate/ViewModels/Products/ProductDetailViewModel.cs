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

        public Product Product { get; private set; }

        public ProductDetailViewModel(IProductService productService)
        {
            _productService = productService;
        }

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
