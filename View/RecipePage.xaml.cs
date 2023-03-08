using RecipeApp.ViewModels;

namespace RecipeApp.View;

public partial class RecipePage : ContentPage
{
    RecipePageViewModel Vm = new RecipePageViewModel();
    bool startPage = false;
    public RecipePage()
    {
        InitializeComponent();
        BindingContext = Vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!startPage)
        {
            await Vm.GiveRecipeValues();
            startPage = true;
        }
    }
}