using WebshopTemplate.ViewModels.Cart;

namespace WebshopTemplate.Views.Cart;

public partial class Cart : ContentPage
{
	public Cart(CartViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}