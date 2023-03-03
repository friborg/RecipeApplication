using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Connections
{
    public class CategoriesRoot
    {
        public Category[] categories { get; set; }
    }

    public class Category
    {
        public string title { get; set; }
        public bool singleChoice { get; set; }
        public Option[] options { get; set; }
    }

    public class Option
    {
        public string displayName { get; set; }
        public string id { get; set; }
    }

}
