using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class DbRelation
    {
        public string LoggedInUsername { get; set; }
        public string ChosenRecipeId { get; set; }
        public string ChosenMealTitle { get; set; }
        public DateOnly CurrentDate { get; set; }
    }
}
