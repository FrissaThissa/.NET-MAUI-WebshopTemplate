using WebshopTemplate.Services;
using WebshopTemplate.Models;
using WebshopTemplate.ViewModels.Home;

namespace WebshopTemplate.Views.Home;

public class HomePage : ContentPage
{
    public HomePage(HomePageViewModel viewModel)
    {
        BindingContext = viewModel;
        StackLayout layout = new StackLayout();
        foreach (Category category in viewModel.Categories)
        {
            layout.Add(new Button
            {
                Text = category.Name,
                Command = viewModel.OnCategoryClicked(category)
            });
        }
        Content = layout;
    }
}