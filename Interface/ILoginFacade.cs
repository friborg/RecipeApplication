using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Interface
{
    internal interface ILoginFacade
    {
        bool LoginSuccess(string username, string password);
    }
}
