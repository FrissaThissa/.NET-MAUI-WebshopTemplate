using WebshopTemplate.ViewModels.Products;

namespace WebshopTemplate.Views.Products;

public partial class ProductOverview : ContentPage
{
	public ProductOverview(ProductOverviewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}