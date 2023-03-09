using MongoDB.Driver.Core.Connections;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
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
        Vm.CreateNewUser();

        if (StatusText.Text == "Registrering lyckades!")
        {
            await Task.Delay(2000);
            await Navigation.PushAsync(new LogInPage());
        }

    }
}