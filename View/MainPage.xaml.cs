namespace RecipeApp;

public partial class MainPage : ContentPage
{
    bool startPage = false;
    ViewModels.MainPageViewModel Vm = new ViewModels.MainPageViewModel();
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
            await Vm.DeleteOldData(); // rensar databasen på recept som ej går att komma åt längre
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

