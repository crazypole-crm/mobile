using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services
{
    public interface IPageNavigationService
    {
        public void LoadPage<T>(Layout contentContainer) where T : Page;
        public void GoBack(Layout contentContainer);
        public void PushPage<T>(T page) where T : Page;
        public Page PopPage();
        public T GetPage<T>() where T : Page;
        public Page PopToRootPage();
        public void InitRootPage(Page page);
    }
}
