using CommunityToolkit.Mvvm.ComponentModel;
using CrazyPoleMobile.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services
{
    public interface IPageNavigationService
    {
        public void LoadPage<View, ViewModel>() where View : Page where ViewModel : ObservableObject;
        public void GoBack();
        public void PushPage<T>(T page) where T : Page;
        public Page PopPage();
        public T GetPage<T>() where T : Page;
        public T GetViewModel<T>() where T : ObservableObject;
        public Page PopToRootPage();
        public void InitRootPage(IRouteController page);
    }
}
