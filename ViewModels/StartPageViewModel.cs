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
            if (Date > DateOnly.FromDateTime(DateTime.Now)) // någonting buggar här (ibland???)
            {
                Date = Date.AddDays(-1);
                //GetRecipesFromDb();
            }
        }
        [RelayCommand]
        private void AddDateClicked()
        {
            Date = Date.AddDays(1);
            //GetRecipesFromDb();
        }

        public void GetRecipesFromDb() 
        {
            List<DbRelation> relations = Databases.RelationsCollection().AsQueryable().ToList();
            //productsFromDb.ForEach(x => Products.Add(x)); ???
            foreach (DbRelation r in relations.Where(r => r.CurrentDate == Date)) // vi är nu inne i det datumet som syns på skärmen
            {
                // måste koppla med mealtitle 
                // kolla vilken mealtitle receptet har, sen spara id:t för det när man klickar på det
                // om det inte finns något recept sparat ska det inte skrivas ut någonting

            }
        }
        public async Task GetRecipeFromSearch(string keyword)
        {
            Random random = new Random();
            string page = random.Next(1, 900).ToString();

            Recipe = await API.GetRndRecipeFromKeyword(keyword, page);
            string id = Recipe.Recipes[0].Id.ToString();
            string name = Recipe.Recipes[0].Title.ToString();

            DbRelation relation = new DbRelation()
            {
                LoggedInUsername = LoggedInUser.Username,
                ChosenRecipeId = id,
                ChosenMealTitle = keyword,
                ChosenRecipeName = name,
                CurrentDate = Date
            };
            Databases.RelationsCollection().DeleteOne(r => r.CurrentDate == Date && r.ChosenMealTitle == keyword);
            Databases.RelationsCollection().InsertOne(relation);
        }
    }
}
