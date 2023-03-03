using MongoDB.Driver;
using RecipeApp.Connections;

namespace RecipeApp.Models;

public partial class LogInPage : ContentPage
{
	ViewModels.LogInPageViewModel LogInPageViewModel = new ViewModels.LogInPageViewModel();
	public LogInPage()
	{
		InitializeComponent();
		BindingContext = LogInPageViewModel;
	}

    private async void ToStartPage(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new StartPage());
    }
}