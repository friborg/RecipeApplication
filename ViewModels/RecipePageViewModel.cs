using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecipeApp.Models;
using RecipeApp.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.ViewModels
{
    internal partial class RecipePageViewModel : ObservableObject
    {
        [ObservableProperty]
        List<string> ingredientItems;
        [ObservableProperty]
        List<string> cookingSteps;
        [ObservableProperty]
        string title;

        public async Task GiveRecipeValues()
        {
            Rootobject recipe = await API.GetRecipeFromId(RecipeId.CurrentRecipeId);
            Title = recipe.Title;

            List<string> items = new(); // det går ej att ge värdena direkt till IngredientItems och CookingSteps
            List<string> steps = new (); // därav gör jag mellanhänder i form av dessa listor som de tidigare nämnda listorna kan kopiera 

            foreach (var i in recipe.IngredientGroups)
            {
                foreach (var item in i.Ingredients)
                {
                    items.Add(item.Text.ToString());
                }
            }
            IngredientItems = items;

            foreach (var item in recipe.CookingSteps)
            {
                steps.Add(item);
            }
            CookingSteps = steps;
        }
    }
}
