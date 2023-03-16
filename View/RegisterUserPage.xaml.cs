using RecipeApp.ViewModels;

namespace RecipeApp.Models;

public partial class RegisterUserPage : ContentPage
{
    RegisterUserPageViewModel Vm = new RegisterUserPageViewModel();
    public RegisterUserPage()
    {
        InitializeComponent();
        BindingContext = Vm;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        bool success = await Vm.CreateNewUser();
        if (success)
        {
            await Task.Delay(2000); // paus för att hinna läsa status-texten
            await Navigation.PushAsync(new LogInPage());
        }
    }
}