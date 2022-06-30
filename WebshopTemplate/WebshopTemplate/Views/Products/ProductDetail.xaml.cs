using WebshopTemplate.ViewModels.Products;
using WebshopTemplate.Services;

namespace WebshopTemplate.Views.Products;

public partial class ProductDetail : ContentPage
{
    private readonly INavigationService _navigationService;

    public ProductDetail(ProductDetailViewModel viewModel, INavigationService navigationService)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _navigationService = navigationService;
    }

    void OnSearchEntryCompleted(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
        _navigationService.NavigateToProductOverview(text);
    }
}