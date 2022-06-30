using WebshopTemplate.ViewModels.Home;
using WebshopTemplate.Services;

namespace WebshopTemplate.Views.Home;

public partial class HomePage : ContentPage
{
    private readonly INavigationService _navigationService;

    public HomePage(HomePageViewModel viewModel, INavigationService navigationService)
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