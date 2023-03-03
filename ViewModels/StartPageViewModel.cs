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
        Rootobject recipe;

        [ObservableProperty]
        string recipeTitle;

        public StartPageViewModel()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            Recipe = new Rootobject();
            //RecipeRoot = new RecipeRoot();
            //RecipeTitle = string.Empty;
        }

        public async Task GetRecipeList()
        {
            Recipe = await Rootobject.GetRecipes();
            RecipeTitle = Recipe.Recipes[0].Title;
        }
    }
}
