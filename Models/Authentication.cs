using MongoDB.Driver;
using RecipeApp.Connections;
using RecipeApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class Authentication : IAuthentication
    {
        public bool IsAuthenticated(string username, string password)
        {
            List<Customer> customerList = Databases.CustomerCollection().AsQueryable().ToList();
            bool succesfulLogin = false; // om listan skulle vara tom så returnerar den fortfarande false
            foreach (var c in customerList)
            {
                if (c.UserName == username && c.Password == password)
                {
                    succesfulLogin = true;
                    break;
                }
                else
                {
                    succesfulLogin = false;
                }
            }
            return succesfulLogin;
        }
    }
}

