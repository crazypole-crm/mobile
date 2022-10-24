using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    class SignUpPageViewModel
    {
        public SignUpPageViewModel()
        {

        }

        public ICommand LoadLogInPage
        {
            get => _loadLogInPage;
            set => _loadLogInPage = value;
        }

        public ICommand LoadHome
        {
            get => _loadHomePage;
            set => _loadHomePage = value;
        }

        private ICommand _loadLogInPage = new Command(async () =>
        {
            await Shell.Current.GoToAsync("//LogInPage", true);
        });

        private ICommand _loadHomePage = new Command(async () =>
        {
            await Shell.Current.GoToAsync("//Home", true);
        });

    }
}
