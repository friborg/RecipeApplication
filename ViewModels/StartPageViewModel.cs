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

        [ObservableProperty]
        ObservableCollection<CategoriesRoot> categoryCollection;

        [ObservableProperty]
        CategoriesRoot category;

        [ObservableProperty]
        string categoryTitle;

        [ObservableProperty]
        ObservableCollection<string> categoryNames;

        [ObservableProperty]
        string categoryId;

        public StartPageViewModel()
        {
            Date = DateOnly.FromDateTime(DateTime.Now);
            Recipe = new Rootobject();
            CategoryNames = new ObservableCollection<string>();
            Category = new CategoriesRoot();
            //RecipeRoot = new RecipeRoot();
            //RecipeTitle = string.Empty;
        }

        public async Task GetRecipeList()
        {
            Recipe = await API.GetRecipes();
            RecipeTitle = Recipe.Recipes[0].Title;
        }

        public async Task GetRecipeCategories()
        {
            //CategoryCollection = await API.GetCategory();
            Category = await API.GetCategory();
            //foreach (var c in CategoryCollection)
            //{
                foreach (var item in Category.categories.Where(c => c.title == "MÅLTID"))
                {
                    CategoryTitle = item.title;
                    foreach (var option in item.options)
                    {
                        CategoryNames.Add(option.id);
                    }
                }
            //}
        }
    }
}
