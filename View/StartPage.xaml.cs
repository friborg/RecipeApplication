using MongoDB.Driver;
using RecipeApp.Connections;
using RecipeApp.View;
using RecipeApp.ViewModels;
using System;

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
        object sender = null;
        EventArgs args = new EventArgs();

        base.OnAppearing();
        if (!startPage)
        {
            GetMealFromDb(sender, args);
            startPage = true;
        }
    }
    public async void GetMealFromDb(object sender, EventArgs e) // kör denna före den hämtar ett nytt recept.
    {
        string placeholder = "Inget valt recept, tryck på knappen för att generera ett random";
        FrukostLabel.Text = placeholder;
        LunchLabel.Text = placeholder;
        MiddagLabel.Text = placeholder;

        List<DbRelation> relation = Databases.RelationsCollection().AsQueryable().ToList();

        foreach (DbRelation item in relation.Where(r => r.CurrentDate == Vm.Date && r.LoggedInUsername == LoggedInUser.Username))
        {
            if (item.ChosenMealTitle == "Frukost")
            {
                FrukostLabel.Text = item.ChosenRecipeName;
            }
            else if (item.ChosenMealTitle == "Lunch")
            {
                LunchLabel.Text = item.ChosenRecipeName;
            }
            else if (item.ChosenMealTitle == "Middag")
            {
                MiddagLabel.Text = item.ChosenRecipeName;
            }
        }
    }
    public async void ViewSelectedtRecipe(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        string mealTitle = btn.Text;
        // döp om text till title : se hela receptet och sen kör en replace på string mealTitle och ta bort : se hela receptet
        List<DbRelation> relations = Databases.RelationsCollection().AsQueryable().ToList();
        foreach (var r in relations.Where(r => r.CurrentDate == Vm.Date && r.LoggedInUsername == LoggedInUser.Username && r.ChosenMealTitle == mealTitle))
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
        await Navigation.PushAsync(new MyPage());
    }
}