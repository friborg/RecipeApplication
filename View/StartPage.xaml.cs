using MongoDB.Driver;
using RecipeApp.Connections;
using RecipeApp.View;
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
            // GetMealFromDb(); fungerar inte här
            startPage = true;
        }
    }
    public void GetMealFromDb(object sender, EventArgs e)
    {
        List<DbRelation> relation = Databases.RelationsCollection().AsQueryable().ToList();

        foreach (DbRelation item in relation.Where(r => r.CurrentDate == Vm.Date && r.LoggedInUsername == LoggedInUser.Username))
        {
            if (item.ChosenMealTitle == "Frukost")
            {
                Frukost.Text = item.ChosenRecipeName;
            }
            else if (item.ChosenMealTitle == "Lunch")
            {
                Lunch.Text = item.ChosenRecipeName;
            }
            else if (item.ChosenMealTitle == "Middag")
            {
                Middag.Text = item.ChosenRecipeName;
            }
        }
    }
    public async void ViewBreakfastRecipe(object sender, EventArgs e)
    {
        List<DbRelation> relations = Databases.RelationsCollection().AsQueryable().ToList();
        foreach (var r in relations.Where(r => r.CurrentDate == Vm.Date && r.LoggedInUsername == LoggedInUser.Username && r.ChosenMealTitle == "Frukost"))
        {
            RecipeId.CurrentRecipeId = r.ChosenRecipeId;
        }
        if (RecipeId.CurrentRecipeId != null)
        {
            await Navigation.PushAsync(new RecipePage());
        }
    }
    public async void ViewLunchRecipe(object sender, EventArgs e)
    {
        List<DbRelation> relations = Databases.RelationsCollection().AsQueryable().ToList();
        foreach (var r in relations.Where(r => r.CurrentDate == Vm.Date && r.LoggedInUsername == LoggedInUser.Username && r.ChosenMealTitle == "Lunch"))
        {
            RecipeId.CurrentRecipeId = r.ChosenRecipeId;
        }
        if (RecipeId.CurrentRecipeId != null)
        {
            await Navigation.PushAsync(new RecipePage());
        }
    }
    public async void ViewDinnerRecipe(object sender, EventArgs e)
    {
        List<DbRelation> relations = Databases.RelationsCollection().AsQueryable().ToList();
        foreach (var r in relations.Where(r => r.CurrentDate == Vm.Date && r.LoggedInUsername == LoggedInUser.Username && r.ChosenMealTitle == "Middag"))
        {
            RecipeId.CurrentRecipeId = r.ChosenRecipeId;
        }
        if (RecipeId.CurrentRecipeId != null)
        {
            await Navigation.PushAsync(new RecipePage());
        }
    }
    public async void MyPageClicked(object sender, EventArgs e)
    {
        // ny sida med my page för loggedinuser
    }

    private void OnBreakfastSelected(object sender, EventArgs e)
    {
        GetMealFromDb(sender, e);
    }

    private void OnLunchSelected(object sender, EventArgs e)
    {
        GetMealFromDb(sender, e);
    }

    private void OnDinnerSelected(object sender, EventArgs e)
    {
        GetMealFromDb(sender, e);
    }
}