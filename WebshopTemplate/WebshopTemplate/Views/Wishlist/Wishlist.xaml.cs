using WebshopTemplate.ViewModels.Wishlist;

namespace WebshopTemplate.Views.Wishlist;

public partial class Wishlist : ContentPage
{
	public Wishlist(WishlistViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}