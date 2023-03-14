using RecipeApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    internal class LoginFacade : ILoginFacade
    {
        private readonly IAuthentication _authentication;
        public LoginFacade()
        {
            _authentication = new Authentication();
        }
        public bool LoginSuccess(string username, string password)
        {
            if (_authentication.IsAuthenticated(username, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
