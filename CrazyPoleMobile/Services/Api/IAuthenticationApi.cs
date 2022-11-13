using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Api
{
    public interface IAuthenticationApi
    {
        public Task Registration(string email, string password);
        public Task LogIn(string email, string password);
        public Task LogOut();
    }
}
