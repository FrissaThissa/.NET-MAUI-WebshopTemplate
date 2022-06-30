using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.Services;
using WebshopTemplate.Models;

namespace WebshopTemplate.ViewModels.Wishlist
{
    public class WishlistViewModel : ViewModelBase
    {
        private readonly IWishlistService _wishlistService;

        public Models.Wishlist Wishlist { get; private set; }

        public WishlistViewModel(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public Command OnRemoveProduct
            => new Command((object parameter) => {
                _wishlistService.RemoveProduct((Product)parameter);
                base.OnPropertyChanged("Wishlist");
            });

        public override Task OnNavigatingTo(object parameter)
        {
            Wishlist = _wishlistService.GetWishlist();
            base.OnPropertyChanged("Wishlist");
            return base.OnNavigatingTo(parameter);
        }
    }
}
