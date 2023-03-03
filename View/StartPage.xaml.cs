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
            Task t = (BindingContext as StartPageViewModel).GetRecipeList(); // kanske ska h�mta recepten tidigare s� att de redan finns, om det g�r att l�sa med binding
            Task task = (BindingContext as StartPageViewModel).GetRecipeCategories();
            startPage = true;
        }

    }
}