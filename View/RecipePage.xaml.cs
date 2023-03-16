using RecipeApp.ViewModels;

namespace RecipeApp.View;

public partial class RecipePage : ContentPage
{
    readonly RecipePageViewModel Vm = new();
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