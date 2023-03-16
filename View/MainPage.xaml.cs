namespace RecipeApp;

public partial class MainPage : ContentPage
{
    bool startPage = false;
    readonly ViewModels.MainPageViewModel Vm = new();
	public MainPage()
	{
		InitializeComponent();
        BindingContext = Vm;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!startPage)
        {
            ViewModels.MainPageViewModel.DeleteOldData(); // rensar databasen på recept som ej går att komma åt längre
            startPage = true;
        }
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

