using WebshopTemplate.ViewModels.Home;
using WebshopTemplate.Services;

namespace WebshopTemplate.Views.Home;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}