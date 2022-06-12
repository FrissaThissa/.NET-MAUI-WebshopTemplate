using WebshopTemplate.Services;
using WebshopTemplate.ViewModels.Home;
using WebshopTemplate.Views.Home;

namespace WebshopTemplate;

public partial class App : Application
{
	public App(HomePage homePage)
	{
		InitializeComponent();

		MainPage = new NavigationPage(homePage);
	}
}
