using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.Connections;
using RecipeApp.Models;
using MongoDB.Driver;

namespace RecipeApp.ViewModels
{
    internal partial class StartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        DateOnly date;

        [ObservableProperty]
        Models.RecipeFromSearch recipe;

        [ObservableProperty]
        string recipeTitle;
        [ObservableProperty]
        int recipeId;

        [ObservableProperty]
        ObservableCollection<string> meals;

        [ObservableProperty]
        string loggedInUserName;

        public StartPageViewModel()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            LoggedInUserName = LoggedInUser.Username;
            Recipe = new Models.RecipeFromSearch();
            Meals = new ObservableCollection<string>()
            {"Frukost", "Lunch", "Middag"};
        }

        [RelayCommand]
        private void SubtractDateClicked()
        {
            if (Date > DateOnly.FromDateTime(DateTime.Now))
            {
                Date = Date.AddDays(-1);
            }
        }
        [RelayCommand]
        private void AddDateClicked()
        {
            Date = Date.AddDays(1);
        }
        [RelayCommand]
        public void BreakfastSelected()
        {
            GetRecipeFromSearch("Frukost");
        }
        [RelayCommand]
        public void LunchSelected()
        {
            GetRecipeFromSearch("Lunch");
        }
        [RelayCommand]
        public void DinnerSelected()
        {
            GetRecipeFromSearch("Middag");
        }

        public async Task GetRecipeFromSearch(string keyword)
        {
            Random random = new Random();
            string page = random.Next(1, 900).ToString();

            Recipe = await API.GetRndRecipeFromKeyword(keyword, page);
            string name = "";
            string id = "";
            foreach (var item in Recipe.Recipes)
            {
                id = item.Id.ToString();
                name = item.Title.ToString();
            }
            if (id != "" && name != "")
            {
                DbRelation relation = new DbRelation()
                {
                    Id = Guid.NewGuid(),
                    LoggedInUsername = LoggedInUser.Username,
                    ChosenRecipeId = id,
                    ChosenMealTitle = keyword,
                    ChosenRecipeName = name,
                    CurrentDate = Date
                };
                Databases.RelationsCollection().DeleteOne(r => r.CurrentDate == Date && r.ChosenMealTitle == keyword && loggedInUserName == LoggedInUser.Username); // denna fungerar, inga dubletter skapas
                Databases.RelationsCollection().InsertOne(relation); // denna fungerar 
            }
        }
    }
}
