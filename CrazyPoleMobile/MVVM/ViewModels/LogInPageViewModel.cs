using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    class LogInPageViewModel
    {


        public LogInPageViewModel()
        {
            
        }

        public ICommand LoadSignUp
        {
            get => _loadSignUpPage;
            set => _loadSignUpPage = value;
        }

        public ICommand LoadHome
        {
            get => _loadHomePage;
            set => _loadHomePage = value;
        }

        private ICommand _loadSignUpPage = new Command( async () => 
        {
            await Shell.Current.GoToAsync("//SignUpPage", true);
        });

        private ICommand _loadHomePage = new Command( async () => 
        {
            await Shell.Current.GoToAsync("//Home", true);
        });
    }
}
