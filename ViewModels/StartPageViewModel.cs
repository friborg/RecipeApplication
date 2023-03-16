using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
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
        RecipeFromSearch recipe;

        [ObservableProperty]
        ObservableCollection<string> meals;

        [ObservableProperty]
        string loggedInUserName;

        public StartPageViewModel()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            LoggedInUserName = LoggedInUser.Username;
            Recipe = new RecipeFromSearch();
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

        public async Task GetRecipeFromSearch(string keyword)
        {
            bool getRecipe = false;
            while (!getRecipe)
            {
                Random random = new Random();
                string page = random.Next(1, 900).ToString(); // slumpar vilken "page" i API-hämtningen den tar receptet ifrån, det lägsta page-antalet är Frukost på runt 900 pages, därav slumpar jag 1-900

                Recipe = await API.GetRndRecipe(keyword, page);
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
                    Databases.RelationsCollection().DeleteOne(r => r.CurrentDate == Date && r.ChosenMealTitle == keyword && LoggedInUserName == LoggedInUser.Username);
                    Databases.RelationsCollection().InsertOne(relation);
                    getRecipe = true;
                }
            }
        }
    }
}
