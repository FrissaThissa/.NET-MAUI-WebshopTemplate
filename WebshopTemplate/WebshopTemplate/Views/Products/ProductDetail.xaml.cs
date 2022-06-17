using WebshopTemplate.ViewModels.Products;

namespace WebshopTemplate.Views.Products;

public partial class ProductDetail : ContentPage
{
	public ProductDetail(ProductDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}