using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Services;
using WebshopTemplate.Models;

namespace WebshopTemplate.ViewModels.Cart
{
    public class CartViewModel : ViewModelBase
    {
        private readonly ICartService _cartService;

        public Models.Cart Cart { get; private set; }

        public CartViewModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        public Command OnRemoveProduct
            => new Command((object parameter) => {
                _cartService.RemoveProduct((Cart_Product)parameter);
                base.OnPropertyChanged("Cart");
            });

        public override Task OnNavigatingTo(object parameter)
        {
            Cart = _cartService.GetCart();
            base.OnPropertyChanged("Cart");
            return base.OnNavigatingTo(parameter);
        }
    }
}
