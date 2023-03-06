using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecipeApp.Connections
{
    public class Rootobject 
    {
        public RecipeRootObject[] Recipes { get; set; }
    }

    public class RecipeRootObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Ingredientgroup[] IngredientGroups { get; set; }
        public Extraportion[] ExtraPortions { get; set; }
        public string DietaryInfo { get; set; }
        public Nutritionperportion NutritionPerPortion { get; set; }
        public bool IsGoodClimateChoice { get; set; }
        public bool IsKeyHole { get; set; }
        public string[] CookingSteps { get; set; }
        public Cookingstepswithtimer[] CookingStepsWithTimers { get; set; }
        public string Difficulty { get; set; }
        public string CookingTime { get; set; }
        public string CookingTimeAbbreviated { get; set; }
        public int Portions { get; set; }
        public string PortionsDescription { get; set; }
        public object[] Categories { get; set; }
        public string[] MdsaCategories { get; set; } // här kan du använda contains, typ alla ingredienser och nyckelord finns här, ex middag, vardag, äggfri, huvudrätt
        public int OfferCount { get; set; }
    }

    public class Nutritionperportion
    {
        public float KCalories { get; set; }
    }

    public class Ingredientgroup
    {
        public int Portions { get; set; }
        public IngredientClass[] Ingredients { get; set; }
    }

    public class IngredientClass
    {
        public string Text { get; set; }
        public int IngredientId { get; set; }
        public float Quantity { get; set; }
        public float MinQuantity { get; set; }
        public string QuantityFraction { get; set; }
        public string Ingredient { get; set; }
        public string Unit { get; set; }
    }

    public class Extraportion
    {
        public int Portions { get; set; }
        public Ingredient1[] Ingredients { get; set; }
    }

    public class Ingredient1
    {
        public string Text { get; set; }
        public int IngredientId { get; set; }
        public float Quantity { get; set; }
        public float MinQuantity { get; set; }
        public string QuantityFraction { get; set; }
        public string Ingredient { get; set; }
        public string Unit { get; set; }
    }

    public class Cookingstepswithtimer
    {
        public string Description { get; set; }
        public int?[] TimersInMinutes { get; set; }
    }

}
