using CrazyPoleMobile.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPoleMobile.Services.Filters
{
    public class DirectionFilter : IFilterElement<TrainingData>
    {
        public string Direction { get; set; }
        
        public DirectionFilter(string direction)
        {
            Direction = direction;
        }

        public bool Match(TrainingData element)
        {
            return element.Direction.Name.ToLower() == Direction.ToLower();
        }
    }
}
