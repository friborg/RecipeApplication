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
            if (Date > DateOnly.FromDateTime(DateTime.Now)) // någonting buggar här, kan inte subtrahera alls 
            {
                Date = Date.AddDays(-1);
            }
        }

        [RelayCommand]
        private void AddDateClicked()
        {
            Date = Date.AddDays(1);
        }

        public async Task GetRecipeFromSearch()
        {
            Random random = new Random();
            string page = random.Next(1, 900).ToString();

            Recipe = await API.GetRndRecipeFromKeyword("Frukost", page);
            RecipeTitle = Recipe.Recipes[0].Title;
            RecipeId = Recipe.Recipes[0].Id;
        }
    }
}
