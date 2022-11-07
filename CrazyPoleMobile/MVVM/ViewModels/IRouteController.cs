using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.ViewModels
{
    public interface IRouteController
    {
        public Layout GetContentBlock { get; }
        public View GetTabBarView { get; }  
    }
}
