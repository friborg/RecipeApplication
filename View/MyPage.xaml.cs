using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.View;

public partial class MyPage : ContentPage
{
	MyPageViewModel Vm = new MyPageViewModel();
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