using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.Connections;

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

        public StartPageViewModel()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
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
            }
        }

        [RelayCommand]
        private void AddDateClicked()
        {
            Date = Date.AddDays(1);
        }
        // om man trycker på get random recipe, så sparas den i db med datum och Meal-title, och det är därifrån vi hämtar recpeten för en collectionview
        // om en slot är null, så skrivs inget ut
        // ex. from DB where Meal = Frukost && Date = Date
        public async Task GetRecipeFromSearch() // OBS!!! Om det senaste receptet alltid blir RecipeTitle så kommer alla ändras!
        {
            Random random = new Random();
            string page = random.Next(1, 900).ToString();

            Recipe = await API.GetRndRecipeFromKeyword("Frukost", page);
            RecipeTitle = Recipe.Recipes[0].Title;
            RecipeId = Recipe.Recipes[0].Id;
        }
    }
}
