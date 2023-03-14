using RecipeApp.Models;
using RecipeApp.ViewModels;

namespace RecipeApp.View;

public partial class MyPage : ContentPage
{
	MyPageViewModel Vm = new MyPageViewModel();
	bool startPage = false;
	public MyPage()
	{
		InitializeComponent();
		BindingContext = Vm;
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		if(!startPage)
		{
			// metoder ??
			startPage = true;
		}
	}

    private async void LogOutUserClicked(object sender, EventArgs e)
    {
		LoggedInUser.Username = null;
		await Navigation.PushAsync(new MainPage()); 
		await Navigation.PopToRootAsync();
    }
}