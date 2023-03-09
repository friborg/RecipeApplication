using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public RecipePageViewModel()
        {

        }

        public async Task GiveRecipeValues()
        {
            Connections.Rootobject recipe = await Connections.API.GetRecipeFromId(Models.RecipeId.CurrentRecipeId);
            Title = recipe.Title;

            List<string> items = new List<string>();
            List<string> steps = new List<string>();

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
