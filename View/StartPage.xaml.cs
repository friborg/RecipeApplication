using MongoDB.Driver;
using RecipeApp.Connections;
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
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    if (!startPage)
    //    {
    //        //await Vm.GetRecipeFromSearch();
    //        startPage = true;
    //    }
    //}

    public async void MyPageClicked(object sender, EventArgs e)
    {
        // ny sida med my page för loggedinuser
    }

    private async void OnBreakfastSelected(object sender, EventArgs e)
    {
        await Vm.GetRecipeFromSearch("Frukost");
    }

    private async void OnLunchSelected(object sender, EventArgs e)
    {
        await Vm.GetRecipeFromSearch("Lunch");
    }

    private async void OnDinnerSelected(object sender, EventArgs e)
    {
        await Vm.GetRecipeFromSearch("Middag");
    }
}