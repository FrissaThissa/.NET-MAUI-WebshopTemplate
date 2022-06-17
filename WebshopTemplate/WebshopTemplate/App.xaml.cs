using WebshopTemplate.Services;
using WebshopTemplate.ViewModels.Home;
using WebshopTemplate.Views.Home;

namespace WebshopTemplate;

public partial class App : Application
{
	public App(INavigationService navigationService)
	{
		InitializeComponent();
		MainPage = new NavigationPage();
		navigationService.NavigateToHomePage();
	}
}
