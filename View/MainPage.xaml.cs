namespace RecipeApp;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void LogInUser(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Models.LogInPage());
    }

    private async void RegisterUser(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Models.RegisterUserPage());
    }
}

