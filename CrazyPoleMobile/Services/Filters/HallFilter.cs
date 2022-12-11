using CrazyPoleMobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Filters
{
    public class HallFilter : IFilterElement<TrainingData>
    {
        public string Hall { get; set; }

        public HallFilter(string direction)
        {
            Hall = direction;
        }

        public HallFilter()
        {
            Hall = string.Empty;
        }

        public bool Match(TrainingData element)
        {
            return element.Direction.Name.ToLower() == Hall.ToLower();
        }
    }
}
