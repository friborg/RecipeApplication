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
        public static async Task<Rootobject> GetRecipes()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/random?numberofrecipes=1");
            request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba3d496483a51a101049260604ab9a14786aa2365de320ab3a78abeaa1e7aeef75c22bdfde805a951adacd3f564a86c86fa");

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync(); // string body får alla värden
                var recipe = JsonSerializer.Deserialize<Rootobject>(body); // allt blir null när jag deserializar 
                return recipe;
            }
        }
        //public static async Task<ObservableCollection<Rootobject>> GetRecipes()
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage(HttpMethod.Get, "https://handla.api.ica.se/api/recipes/random?numberofrecipes=2");
        //    request.Headers.Add("Cookie", "TS01841c8a=01f0ddaba3359f2db755dc1f2f295fb948b9e984015b7290243f84e37d607467a8cf308de497e9d36739d16fab7efe4d784b4cffe6");

        //    using (var response = await client.SendAsync(request))
        //    {
        //        response.EnsureSuccessStatusCode();
        //        var body = await response.Content.ReadAsStringAsync();
        //        var recipe = JsonSerializer.Deserialize<ObservableCollection<Rootobject>>(body);
        //        return recipe;
        //    }
        //}

        public RecipeRoot[] Recipes { get; set; }
    }

    public class RecipeRoot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Ingredientgroup[] IngredientGroups { get; set; }
        public Extraportion[] ExtraPortions { get; set; }
        public string PreambleHTML { get; set; }
        public string DietaryInfo { get; set; }
        public Nutritionperportion NutritionPerPortion { get; set; }
        public bool IsGoodClimateChoice { get; set; }
        public bool IsKeyHole { get; set; }
        public string[] CookingSteps { get; set; }
        public Cookingstepswithtimer[] CookingStepsWithTimers { get; set; }
        public string CurrentUsersRating { get; set; }
        public string AverageRating { get; set; }
        public string Difficulty { get; set; }
        public string CookingTime { get; set; }
        public string CookingTimeAbbreviated { get; set; }
        public int Portions { get; set; }
        public string PortionsDescription { get; set; }
        public object[] Categories { get; set; }
        public string[] MdsaCategories { get; set; }
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
