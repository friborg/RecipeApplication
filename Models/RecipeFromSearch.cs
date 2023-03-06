using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
        public class RecipeFromSearch
        {
            public int NumberOfPages { get; set; }
            public Recipe[] Recipes { get; set; }
            public int TotalNumberOfRecipes { get; set; }
            public string Msg { get; set; }
        }

        public class Recipe
        {
            public int Id { get; set; }
            public int ImageId { get; set; }
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string PreambleHTML { get; set; }
            public string Difficulty { get; set; }
            public string CookingTime { get; set; }
            public string CookingTimeAbbreviated { get; set; }
            public int CookingTimeMinutes { get; set; }
            public int CommentCount { get; set; }
            public string AverageRating { get; set; }
            public int IngredientCount { get; set; }
            public int OfferCount { get; set; }
            public bool IsGoodClimateChoice { get; set; }
            public bool IsKeyHole { get; set; }
            public string NumberOfUserRatings { get; set; }
            public Ingredientgroup[] IngredientGroups { get; set; }
        }

        public class Ingredientgroup
        {
            public string GroupName { get; set; }
            public int Portions { get; set; }
            public Ingredient[] Ingredients { get; set; }
        }

        public class Ingredient
        {
            public string Text { get; set; }
            public int IngredientId { get; set; }
            public float Quantity { get; set; }
            public float MinQuantity { get; set; }
            public string QuantityFraction { get; set; }
            public string Unit { get; set; }
            public string IngredientName { get; set; }
        }

    }
