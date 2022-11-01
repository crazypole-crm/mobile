using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.MVVM.Views.CustomControls
{
    public class CustomEntry : View, ICustomEntry
    {
        public string Text { get; set; }
        public Color TextColor { get; set; }
    }
}
