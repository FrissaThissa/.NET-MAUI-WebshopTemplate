using WebshopTemplate.Services;

namespace WebshopTemplate;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Register Views
        builder.Services.AddTransient<Views.Home.HomePage>();
		builder.Services.AddTransient<Views.Products.ProductOverview>();
		builder.Services.AddTransient<Views.Products.ProductDetail>();
        builder.Services.AddTransient<Views.Cart.Cart>();
        builder.Services.AddTransient<Views.Wishlist.Wishlist>();

        //Register ViewModels
        builder.Services.AddTransient<ViewModels.Home.HomePageViewModel>();
        builder.Services.AddTransient<ViewModels.Products.ProductOverviewViewModel>();
        builder.Services.AddTransient<ViewModels.Products.ProductDetailViewModel>();
        builder.Services.AddTransient<ViewModels.Cart.CartViewModel>();
        builder.Services.AddTransient<ViewModels.Wishlist.WishlistViewModel>();

        //Register Services
        builder.Services.AddScoped<ICategoryService, CategoryService>();
		builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<ICartService, CartService>();
        builder.Services.AddScoped<IWishlistService, WishlistService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

		return builder.Build();
	}
}
