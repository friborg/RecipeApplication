namespace RecipeApp.Models;

public partial class LogInPage : ContentPage
{
    ViewModels.LogInPageViewModel Vm = new();
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
            await Task.Delay(1500); // paus f�r att hinna l�sa status-meddelande
            await Navigation.PushAsync(new StartPage());
        }
    }

    private void ShowPasswordClicked(object sender, EventArgs e)
    {
        if (PasswordEntry.IsPassword == true)
        {
            PasswordEntry.IsPassword = false;
            TogglePasswordBtn.Text = "D�lj l�senord";
        }
        else if (PasswordEntry.IsPassword == false)
        {
            PasswordEntry.IsPassword = true;
            TogglePasswordBtn.Text = "Visa l�senord";
        }
    }
}