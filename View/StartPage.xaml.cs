using RecipeApp.ViewModels;

namespace RecipeApp.Models;

public partial class StartPage : ContentPage
{
    StartPageViewModel Vm = new StartPageViewModel();
    bool startPage = false;
    public StartPage()
    {
        InitializeComponent();
        BindingContext = Vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!startPage)
        {
            await Vm.GetRecipeFromSearch();
            //await Vm.GetRecipeCategories();
            startPage = true;
        }

    }
}