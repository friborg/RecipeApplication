using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.View;

public partial class MyPage : ContentPage
{
    readonly MyPageViewModel Vm = new();
	public MyPage()
	{
		InitializeComponent();
		BindingContext = Vm;
	}

    private async void LogOutUserClicked(object sender, EventArgs e)
    {
		LoggedInUser.Username = null;
		await Navigation.PushAsync(new MainPage());
    }
}