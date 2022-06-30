using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopTemplate.ViewModels;
using WebshopTemplate.Models;
using WebshopTemplate.Views.Products;
using WebshopTemplate.Views.Home;

namespace WebshopTemplate.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _services;
        private readonly IProductService _productService;


        public NavigationService(IServiceProvider serviceProvider, IProductService productService)
        {
            _services = serviceProvider;
            _productService = productService;
        }

        public Task NavigateToHomePage()
            => NavigateToPage<HomePage>();

        public Task NavigateToProductOverview(Category category)
            => NavigateToPage<ProductOverview>(category);

        public Task NavigateToProductDetail(Product product)
            => NavigateToPage<ProductDetail>(product);

        public Task NavigateToCart()
            => NavigateToPage<Views.Cart.Cart>();

        public Task NavigateToWishlist()
            => NavigateToPage<Views.Wishlist.Wishlist>();

        private async Task NavigateToPage<T>(object parameter = null) where T : Page
        {
            var toPage = ResolvePage<T>();
            if (toPage is not null)
            {
                //Subscribe to the toPage's NavigatedTo event
                toPage.NavigatedTo += Page_NavigatedTo;
                //Get VM of the toPage
                var toViewModel = GetPageViewModelBase(toPage);
                //Call navigatingTo on VM, passing in the paramter
                if (toViewModel is not null)
                    await toViewModel.OnNavigatingTo(parameter);
                //Navigate to requested page
                await Navigation.PushAsync(toPage, true);
                //Subscribe to the toPage's NavigatedFrom event
                toPage.NavigatedFrom += Page_NavigatedFrom;
            }
            else
                throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }

        private async void Page_NavigatedTo(object? sender, NavigatedToEventArgs e)
            => await CallNavigatedTo(sender as Page);

        private Task CallNavigatedTo(Page? p)
        {
            var fromViewModel = GetPageViewModelBase(p);
            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedTo();
            return Task.CompletedTask;
        }

        private async void Page_NavigatedFrom(object? sender, NavigatedFromEventArgs e)
        {
            //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
            //If that entry equals the sender, it means we navigated forward from the sender to another page
            bool isForwardNavigation = Navigation.NavigationStack.Count > 1
                && Navigation.NavigationStack[^2] == sender;
            if (sender is Page thisPage)
            {
                if (!isForwardNavigation)
                {
                    thisPage.NavigatedTo -= Page_NavigatedTo;
                    thisPage.NavigatedFrom -= Page_NavigatedFrom;
                }
                await CallNavigatedFrom(thisPage, isForwardNavigation);
            }
        }

        private Task CallNavigatedFrom(Page p, bool isForward)
        {
            var fromViewModel = GetPageViewModelBase(p);
            if (fromViewModel is not null)
                return fromViewModel.OnNavigatedFrom(isForward);
            return Task.CompletedTask;
        }

        private T? ResolvePage<T>() where T : Page
            => _services.GetService<T>();

        private ViewModelBase? GetPageViewModelBase(Page? p)
            => p?.BindingContext as ViewModelBase;

        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }
    }
}
