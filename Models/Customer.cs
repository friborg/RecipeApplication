using Microsoft.EntityFrameworkCore;
using RecipeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    [Index(nameof(UserName), IsUnique = true)]

    public class Customer
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; }
    }
}
