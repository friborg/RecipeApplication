using MongoDB.Driver;
using RecipeApp.Connections;

namespace RecipeApp.Models;

public partial class LogInPage : ContentPage
{
    ViewModels.LogInPageViewModel Vm = new ViewModels.LogInPageViewModel();
    public LogInPage()
    {
        InitializeComponent();
        BindingContext = Vm;
    }

    private async void ToStartPage(object sender, EventArgs e)
    {
        bool successLogin = await Vm.TryLogIn();
        if (successLogin)
        {
            await Task.Delay(1000);
            await Navigation.PushAsync(new StartPage());
        }
    }

    private void ShowPasswordClicked(object sender, EventArgs e)
    {
        if (PasswordEntry.IsPassword == true)
        {
            PasswordEntry.IsPassword = false;
            TogglePasswordBtn.Text = "Dölj lösenord";
        }
        else if (PasswordEntry.IsPassword == false)
        {
            PasswordEntry.IsPassword = true;
            TogglePasswordBtn.Text = "Visa lösenord";
        }
    }
}