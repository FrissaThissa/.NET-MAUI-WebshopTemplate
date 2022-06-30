using WebshopTemplate.ViewModels.Products;
using WebshopTemplate.Services;

namespace WebshopTemplate.Views.Products;

public partial class ProductOverview : ContentPage
{
    private readonly INavigationService _navigationService;
	public ProductOverview(ProductOverviewViewModel viewModel, INavigationService navigationService)
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